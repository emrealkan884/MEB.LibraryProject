using Application.Features.Oduncler.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Domain.Enums;

namespace Application.Features.Oduncler.Commands.Create;

public class CreateOduncCommand : IRequest<CreatedOduncResponse>
{
    public required Guid KopyaId { get; set; }
    public required Guid KullaniciId { get; set; }
    public required Guid KutuphaneId { get; set; }
    public DateTime? SonTeslimTarihi { get; set; } // kullanıcı isterse verebilir, default biz atayacağız
    public bool IleriTarihIcinMi { get; set; } // rezervasyon mu, hemen ödünç mü?

    public class CreateOduncCommandHandler : IRequestHandler<CreateOduncCommand, CreatedOduncResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOduncRepository _oduncRepository;
        private readonly OduncBusinessRules _oduncBusinessRules;

        public CreateOduncCommandHandler(IMapper mapper, IOduncRepository oduncRepository,
            OduncBusinessRules oduncBusinessRules)
        {
            _mapper = mapper;
            _oduncRepository = oduncRepository;
            _oduncBusinessRules = oduncBusinessRules;
        }

        public async Task<CreatedOduncResponse> Handle(CreateOduncCommand request, CancellationToken cancellationToken)
        {
            // Kitap uygun mu?
            await _oduncBusinessRules.KitapMusaitOlmali(request.KopyaId, cancellationToken);

            // Odunc nesnesini oluştur
            var odunc = new Odunc(
                request.KopyaId,
                request.KullaniciId,
                request.KutuphaneId,
                DateTime.Now, // kayıt tarihi
                request.SonTeslimTarihi ?? DateTime.Now.AddDays(15) // varsayılan 15 gün
            );

            // Durumu ayarla
            odunc.Durum = request.IleriTarihIcinMi ? OduncDurum.RezerveEdildi : OduncDurum.OduncVerildi;

            // Veritabanına ekle
            await _oduncRepository.AddAsync(odunc);

            // Response döndür
            return _mapper.Map<CreatedOduncResponse>(odunc);
        }
    }
}