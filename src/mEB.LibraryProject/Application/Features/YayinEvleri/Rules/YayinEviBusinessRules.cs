using Application.Features.YayinEvleri.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.YayinEvleri.Rules;

public class YayinEviBusinessRules : BaseBusinessRules
{
    private readonly IYayinEviRepository _yayinEviRepository;
    private readonly ILocalizationService _localizationService;

    public YayinEviBusinessRules(IYayinEviRepository yayinEviRepository, ILocalizationService localizationService)
    {
        _yayinEviRepository = yayinEviRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, YayinEvleriBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task YayinEviShouldExistWhenSelected(YayinEvi? yayinEvi)
    {
        if (yayinEvi == null)
            await throwBusinessException(YayinEvleriBusinessMessages.YayinEviNotExists);
    }

    public async Task YayinEviIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        YayinEvi? yayinEvi = await _yayinEviRepository.GetAsync(
            predicate: ye => ye.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await YayinEviShouldExistWhenSelected(yayinEvi);
    }
}