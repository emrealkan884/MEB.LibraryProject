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
        public Guid? KopyaBirimId { get; set; }
    public required Guid KullaniciId { get; set; }
    public required Guid KutuphaneId { get; set; }
    public DateTime? SonTeslimTarihi { get; set; } // kullanıcı isterse verebilir, default biz atayacağız
    public bool IleriTarihIcinMi { get; set; } // rezervasyon mu, hemen ödünç mü?

    public class CreateOduncCommandHandler : IRequestHandler<CreateOduncCommand, CreatedOduncResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOduncRepository _oduncRepository;
        private readonly IKopyaBirimRepository _kopyaBirimRepository;
        private readonly OduncBusinessRules _oduncBusinessRules;

        public CreateOduncCommandHandler(IMapper mapper, IOduncRepository oduncRepository,
            IKopyaBirimRepository kopyaBirimRepository,
            OduncBusinessRules oduncBusinessRules)
        {
            _mapper = mapper;
            _oduncRepository = oduncRepository;
            _kopyaBirimRepository = kopyaBirimRepository;
            _oduncBusinessRules = oduncBusinessRules;
        }

        public async Task<CreatedOduncResponse> Handle(CreateOduncCommand request, CancellationToken cancellationToken)
        {
            // Uygunluk kontrolü
            if (request.KopyaBirimId.HasValue)
                await _oduncBusinessRules.KopyaBirimMusaitOlmali(request.KopyaBirimId.Value, cancellationToken);
            else
                await _oduncBusinessRules.KitapMusaitOlmali(request.KopyaId, cancellationToken);

            // Odunc nesnesini oluştur
            var odunc = new Odunc(
                request.KopyaId,
                request.KullaniciId,
                request.KutuphaneId,
                DateTime.Now, // kayıt tarihi
                request.SonTeslimTarihi ?? DateTime.Now.AddDays(15) // varsayılan 15 gün
            );
            odunc.KopyaBirimId = request.KopyaBirimId;

            // Durumu ayarla
            odunc.Durum = request.IleriTarihIcinMi ? OduncDurum.RezerveEdildi : OduncDurum.OduncVerildi;

            // Veritabanına ekle
            await _oduncRepository.AddAsync(odunc);

            // KopyaBirim durumu güncelle
            if (request.KopyaBirimId.HasValue)
            {
                var birim = await _kopyaBirimRepository.GetAsync(x => x.Id == request.KopyaBirimId.Value, cancellationToken: cancellationToken);
                if (birim != null)
                {
                    birim.Durum = odunc.Durum;
                    await _kopyaBirimRepository.UpdateAsync(birim);
                }
            }

            // Response döndür
            return _mapper.Map<CreatedOduncResponse>(odunc);
        }
    }
}