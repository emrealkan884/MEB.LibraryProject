using Application.Features.Konumlar.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Konumlar.Rules;

public class KonumBusinessRules : BaseBusinessRules
{
    private readonly IKonumRepository _konumRepository;
    private readonly ILocalizationService _localizationService;

    public KonumBusinessRules(IKonumRepository konumRepository, ILocalizationService localizationService)
    {
        _konumRepository = konumRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, KonumlarBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task KonumShouldExistWhenSelected(Konum? konum)
    {
        if (konum == null)
            await throwBusinessException(KonumlarBusinessMessages.KonumNotExists);
    }

    public async Task KonumIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Konum? konum = await _konumRepository.GetAsync(
            predicate: k => k.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await KonumShouldExistWhenSelected(konum);
    }
}