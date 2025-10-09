using Application.Features.Kitaplar.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using Domain.Enums;

namespace Application.Services.KitapBaskilar;

public class KitapBaskiManager : IKitapBaskiService
{
    private readonly KitapBaskiBusinessRules _rules;
    private readonly IKitapBaskiRepository _kitapBaskiRepository;

    public KitapBaskiManager(KitapBaskiBusinessRules rules, IKitapBaskiRepository kitapBaskiRepository)
    {
        _rules = rules;
        _kitapBaskiRepository = kitapBaskiRepository;
    }

    public string NormalizeIsbn(string isbn) => _rules.NormalizeIsbn(isbn);
    public void ValidateIsbnFormat(string isbn) => _rules.ValidateIsbnFormat(isbn);

    public async Task<KitapBaski> CreateAsync(Kitap kitap, Guid yayinEviId, string isbn, string? sayfaSayisi, short? basimYili, string? basimYeri, string? baskiBilgisi, CiltTipi? ciltTipi)
    {
        var normalized = _rules.NormalizeIsbn(isbn);
        _rules.ValidateIsbnFormat(normalized);

        var baski = new KitapBaski(kitap.Id, yayinEviId, normalized, sayfaSayisi, basimYili, basimYeri, baskiBilgisi, ciltTipi);
        return await _kitapBaskiRepository.AddAsync(baski);
    }
}


