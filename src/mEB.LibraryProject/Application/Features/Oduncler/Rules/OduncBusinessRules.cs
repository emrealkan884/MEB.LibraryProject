using Application.Features.Oduncler.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using Domain.Enums;

namespace Application.Features.Oduncler.Rules;

public class OduncBusinessRules : BaseBusinessRules
{
    private readonly IOduncRepository _oduncRepository;
    private readonly ILocalizationService _localizationService;

    public OduncBusinessRules(IOduncRepository oduncRepository, ILocalizationService localizationService)
    {
        _oduncRepository = oduncRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, OdunclerBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task OduncShouldExistWhenSelected(Odunc? odunc)
    {
        if (odunc == null)
            await throwBusinessException(OdunclerBusinessMessages.OduncNotExists);
    }

    public async Task OduncIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Odunc? odunc = await _oduncRepository.GetAsync(
            predicate: o => o.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await OduncShouldExistWhenSelected(odunc);
    }
    
    
    // Kitap şu anda ödünçte veya rezerve edilmiş olmamalı.
    public async Task KitapMusaitOlmali(Guid kopyaId, CancellationToken cancellationToken)
    {
        bool mevcutOdunc = await _oduncRepository.AnyAsync(
            predicate: o => o.KopyaId == kopyaId &&
                            (o.Durum == OduncDurum.OduncVerildi || o.Durum == OduncDurum.RezerveEdildi),
            cancellationToken: cancellationToken
        );

        if (mevcutOdunc)
            await throwBusinessException(OdunclerBusinessMessages.KitapMusaitDegil);
    }

}