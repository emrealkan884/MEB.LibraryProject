using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Eser : Entity<Guid>
{
    public Eser()
    {
    }

    public Eser(string adi, string dilkodu, string aciklama, string deweyKodu, string marcVerisi, EserTipi eserTipi) : this()
    {
        Adi = adi;
        DilKodu = dilkodu;
        Aciklama = aciklama;
        DeweyKodu = deweyKodu;
        MarcVerisi = marcVerisi;
        EserTipi = eserTipi;
    }

    public string Adi { get; set; }
    public string DilKodu { get; set; }
    public string Aciklama { get; set; }
    public string? DeweyKodu { get; set; } // Dewey kodu
    public string? MarcVerisi { get; set; } // MARC kaydı (JSON/XML)
    public EserTipi EserTipi { get; set; } 

    // Navigation
    public ICollection<Kitap> Kitaplar { get; set; } = new List<Kitap>();
    public ICollection<EserYazar> EserYazarlar { get; set; } = new List<EserYazar>();
}