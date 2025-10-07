using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;

public class KitapBusinessRules : BaseBusinessRules
{
    private readonly IKitapRepository _kitapRepository;
    private readonly ILocalizationService _localizationService;

    public KitapBusinessRules(IKitapRepository kitapRepository, ILocalizationService localizationService)
    {
        _kitapRepository = kitapRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, KitaplarBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task KitapShouldExistWhenSelected(Eser? eser)
    {
        if (eser == null)
            await throwBusinessException(KitaplarBusinessMessages.KitapNotExists);
    }

    public async Task KitapIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Kitap? kitap = await _kitapRepository.GetAsync(
            predicate: e => e.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await KitapShouldExistWhenSelected(kitap);
    }
}