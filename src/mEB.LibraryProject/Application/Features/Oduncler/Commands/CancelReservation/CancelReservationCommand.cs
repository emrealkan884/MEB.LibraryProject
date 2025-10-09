using Application.Features.Oduncler.Rules;
using Application.Services.Repositories;
using Domain.Enums;
using MediatR;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;

namespace Application.Features.Oduncler.Commands.RezervasyonIptal;

public class RezervasyonIptalCommand : IRequest<Unit>
{
    public Guid OduncId { get; set; }

    public class Handler : IRequestHandler<RezervasyonIptalCommand, Unit>
    {
        private readonly IOduncRepository _oduncRepository;
        private readonly OduncBusinessRules _rules;
        public Handler(IOduncRepository oduncRepository, OduncBusinessRules rules)
        { _oduncRepository = oduncRepository; _rules = rules; }

        public async Task<Unit> Handle(RezervasyonIptalCommand request, CancellationToken ct)
        {
            var odunc = await _oduncRepository.GetAsync(o => o.Id == request.OduncId, cancellationToken: ct);
            await _rules.OduncShouldExistWhenSelected(odunc);
            if (odunc!.Durum != OduncDurum.RezerveEdildi)
                throw new BusinessException("Sadece rezerve kayıt iptal edilebilir.");
            odunc.Durum = OduncDurum.IptalEdildi;
            await _oduncRepository.UpdateAsync(odunc);
            return Unit.Value;
        }
    }
}


