using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Kutuphane : Entity<Guid>
{
    public Kutuphane() { }

    public Kutuphane(string adi, string adres, KurumTuru kurumTuru, Guid? ustKutuphaneId)
    {
        Adi = adi;
        Adres = adres;
        KurumTuru = kurumTuru;
        UstKutuphaneId = ustKutuphaneId;
    }

    public string Adi { get; set; }
    public string Adres { get; set; }
    public KurumTuru KurumTuru { get; set; }
    public Guid? UstKutuphaneId { get; set; }

    // Navigation
    public Kutuphane? UstKutuphane { get; set; }
    public ICollection<Kopya> Kopyalar { get; set; } = new List<Kopya>();
    public ICollection<Konum> Konumlar { get; set; } = new List<Konum>();
}

