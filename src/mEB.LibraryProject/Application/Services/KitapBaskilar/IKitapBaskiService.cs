using Domain.Entities;
using Domain.Enums;

namespace Application.Services.KitapBaskilar;

public interface IKitapBaskiService
{
    string NormalizeIsbn(string isbn);
    void ValidateIsbnFormat(string isbn);
    Task<KitapBaski> CreateAsync(Kitap kitap, Guid yayinEviId, string isbn, string? sayfaSayisi, short? basimYili, string? basimYeri, string? baskiBilgisi, CiltTipi? ciltTipi);
}


