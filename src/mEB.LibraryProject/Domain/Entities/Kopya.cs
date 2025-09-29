using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Kopya : Entity<Guid>
{
    public Kopya() { }

    public Kopya(Guid kitapId, Guid kutuphaneId, string barkod)
    {
        KitapId = kitapId;
        KutuphaneId = kutuphaneId;
        Barkod = barkod;
    }

    public Guid KitapId { get; set; }
    public Guid KutuphaneId { get; set; }
    public string Barkod { get; set; }

    // Navigation
    public Kitap Kitap { get; set; }
    public Kutuphane Kutuphane { get; set; }
    public ICollection<KopyaKonum> KopyaKonumlar { get; set; } = new List<KopyaKonum>();
}
