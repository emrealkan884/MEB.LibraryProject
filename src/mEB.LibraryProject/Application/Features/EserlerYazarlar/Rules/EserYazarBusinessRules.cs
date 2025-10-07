using Application.Features.EserlerYazarlar.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.EserlerYazarlar.Rules;

public class EserYazarBusinessRules : BaseBusinessRules
{
    private readonly IEserYazarRepository _eserYazarRepository;
    private readonly ILocalizationService _localizationService;

    public EserYazarBusinessRules(IEserYazarRepository eserYazarRepository, ILocalizationService localizationService)
    {
        _eserYazarRepository = eserYazarRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, EserlerYazarlarBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task EserYazarShouldExistWhenSelected(EserYazar? eserYazar)
    {
        if (eserYazar == null)
            await throwBusinessException(EserlerYazarlarBusinessMessages.EserYazarNotExists);
    }

    public async Task EserYazarIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        EserYazar? eserYazar = await _eserYazarRepository.GetAsync(
            predicate: ey => ey.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await EserYazarShouldExistWhenSelected(eserYazar);
    }
}