using Application.Features.Oduncler.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Oduncler.Commands.TopluOduncVer;

public class TopluOduncVerCommand : IRequest<IReadOnlyList<Guid>>
{
    public required Guid KullaniciId { get; set; }
    public required Guid KutuphaneId { get; set; }
    public required List<Guid> KopyaBirimIds { get; set; }
    public int? GunSayisi { get; set; }

    public class Handler : IRequestHandler<TopluOduncVerCommand, IReadOnlyList<Guid>>
    {
        private readonly IOduncRepository _oduncRepository;
        private readonly IKopyaBirimRepository _kopyaBirimRepository;
        private readonly OduncBusinessRules _rules;
        public Handler(IOduncRepository oduncRepository, IKopyaBirimRepository kopyaBirimRepository, OduncBusinessRules rules)
        { _oduncRepository = oduncRepository; _kopyaBirimRepository = kopyaBirimRepository; _rules = rules; }

        public async Task<IReadOnlyList<Guid>> Handle(TopluOduncVerCommand request, CancellationToken ct)
        {
            var createdIds = new List<Guid>();
            foreach (var birimId in request.KopyaBirimIds)
            {
                await _rules.KopyaBirimMusaitOlmali(birimId, ct);

                var birim = await _kopyaBirimRepository.GetAsync(x => x.Id == birimId, cancellationToken: ct);
                if (birim is null) continue;

                var odunc = new Odunc(birim.KopyaId, request.KullaniciId, request.KutuphaneId, DateTime.Now,
                    DateTime.Now.AddDays(request.GunSayisi ?? 15))
                {
                    KopyaBirimId = birimId,
                    Durum = OduncDurum.OduncVerildi
                };
                await _oduncRepository.AddAsync(odunc);
                createdIds.Add(odunc.Id);

                birim.Durum = OduncDurum.OduncVerildi;
                await _kopyaBirimRepository.UpdateAsync(birim);
            }
            return createdIds;
        }
    }
}


