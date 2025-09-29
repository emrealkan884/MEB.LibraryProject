using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Eser : Entity<Guid>
{
    public Eser()
    {
    }

    public Eser(string adi, string dilkodu, string aciklama) : this()
    {
        Adi = adi;
        DilKodu = dilkodu;
        Aciklama = aciklama;
    }

    public string Adi { get; set; }
    public string DilKodu { get; set; }
    public string Aciklama { get; set; }


    // Navigation
    public ICollection<Kitap> Kitaplar { get; set; } = new List<Kitap>();
    public ICollection<EserYazar> EserYazarlar { get; set; } = new List<EserYazar>();
}