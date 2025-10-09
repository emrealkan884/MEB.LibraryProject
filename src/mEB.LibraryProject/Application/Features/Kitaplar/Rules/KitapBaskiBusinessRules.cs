using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;

namespace Application.Features.Kitaplar.Rules;

public class KitapBaskiBusinessRules : BaseBusinessRules
{
    private readonly IKitapBaskiRepository _kitapBaskiRepository;
    private readonly ILocalizationService _localizationService;

    public KitapBaskiBusinessRules(IKitapBaskiRepository kitapBaskiRepository, ILocalizationService localizationService)
    {
        _kitapBaskiRepository = kitapBaskiRepository;
        _localizationService = localizationService;
    }

    public string NormalizeIsbn(string isbn)
    {
        if (string.IsNullOrWhiteSpace(isbn)) return isbn;
        var cleaned = new string(isbn.Where(char.IsLetterOrDigit).ToArray());
        return cleaned.ToUpperInvariant();
    }

    public void ValidateIsbnFormat(string isbn)
    {
        if (!(IsValidIsbn10(isbn) || IsValidIsbn13(isbn)))
            throw new BusinessException("Geçersiz ISBN formatı");
    }

    private bool IsValidIsbn10(string isbn)
    {
        if (isbn.Length != 10) return false;
        int sum = 0;
        for (int i = 0; i < 9; i++)
        {
            if (!char.IsDigit(isbn[i])) return false;
            sum += (10 - i) * (isbn[i] - '0');
        }
        int check = isbn[9] == 'X' ? 10 : (char.IsDigit(isbn[9]) ? isbn[9] - '0' : -1);
        if (check < 0) return false;
        sum += check;
        return sum % 11 == 0;
    }

    private bool IsValidIsbn13(string isbn)
    {
        if (isbn.Length != 13 || !isbn.All(char.IsDigit)) return false;
        int sum = 0;
        for (int i = 0; i < 12; i++)
        {
            int d = isbn[i] - '0';
            sum += (i % 2 == 0) ? d : 3 * d;
        }
        int check = (10 - (sum % 10)) % 10;
        return check == (isbn[12] - '0');
    }
}


