using Application.Features.KopyaKonums.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.KopyaKonums.Rules;

public class KopyaKonumBusinessRules : BaseBusinessRules
{
    private readonly IKopyaKonumRepository _kopyaKonumRepository;
    private readonly ILocalizationService _localizationService;

    public KopyaKonumBusinessRules(IKopyaKonumRepository kopyaKonumRepository, ILocalizationService localizationService)
    {
        _kopyaKonumRepository = kopyaKonumRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, KopyaKonumsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task KopyaKonumShouldExistWhenSelected(KopyaKonum? kopyaKonum)
    {
        if (kopyaKonum == null)
            await throwBusinessException(KopyaKonumsBusinessMessages.KopyaKonumNotExists);
    }

    public async Task KopyaKonumIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        KopyaKonum? kopyaKonum = await _kopyaKonumRepository.GetAsync(
            predicate: kk => kk.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await KopyaKonumShouldExistWhenSelected(kopyaKonum);
    }
}