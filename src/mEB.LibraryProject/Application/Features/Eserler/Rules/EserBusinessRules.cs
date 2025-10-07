using Application.Features.Eserler.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Eserler.Rules;

public class EserBusinessRules : BaseBusinessRules
{
    private readonly IEserRepository _eserRepository;
    private readonly ILocalizationService _localizationService;

    public EserBusinessRules(IEserRepository eserRepository, ILocalizationService localizationService)
    {
        _eserRepository = eserRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, EserlerBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task EserShouldExistWhenSelected(Eser? eser)
    {
        if (eser == null)
            await throwBusinessException(EserlerBusinessMessages.EserNotExists);
    }

    public async Task EserIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Eser? eser = await _eserRepository.GetAsync(
            predicate: e => e.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await EserShouldExistWhenSelected(eser);
    }
}