using Application.Features.Kopyas.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Kopyas.Rules;

public class KopyaBusinessRules : BaseBusinessRules
{
    private readonly IKopyaRepository _kopyaRepository;
    private readonly ILocalizationService _localizationService;

    public KopyaBusinessRules(IKopyaRepository kopyaRepository, ILocalizationService localizationService)
    {
        _kopyaRepository = kopyaRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, KopyasBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task KopyaShouldExistWhenSelected(Kopya? kopya)
    {
        if (kopya == null)
            await throwBusinessException(KopyasBusinessMessages.KopyaNotExists);
    }

    public async Task KopyaIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Kopya? kopya = await _kopyaRepository.GetAsync(
            predicate: k => k.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await KopyaShouldExistWhenSelected(kopya);
    }
}