using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class KitapBaski : Entity<Guid>
{
    public KitapBaski() { }

    public KitapBaski(Guid kitapId, Guid yayinEviId, string isbn, string? sayfaSayisi,
        short? basimYili, string? basimYeri, string? baskiBilgisi, CiltTipi? ciltTipi)
    {
        KitapId = kitapId;
        YayinEviId = yayinEviId;
        Isbn = isbn;
        SayfaSayisi = sayfaSayisi;
        BasimYili = basimYili;
        BasimYeri = basimYeri;
        BaskiBilgisi = baskiBilgisi;
        CiltTipi = ciltTipi;
    }

    public Guid KitapId { get; set; }
    public Guid YayinEviId { get; set; }

    public string Isbn { get; set; } = string.Empty;
    public string? SayfaSayisi { get; set; }
    public short? BasimYili { get; set; }
    public string? BasimYeri { get; set; }
    public string? BaskiBilgisi { get; set; }
    public CiltTipi? CiltTipi { get; set; }

    // Navigation
    public virtual Kitap Kitap { get; set; } = null!;
    public virtual YayinEvi YayinEvi { get; set; } = null!;
}


