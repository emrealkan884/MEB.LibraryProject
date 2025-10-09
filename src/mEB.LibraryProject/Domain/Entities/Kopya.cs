using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Kopya : Entity<Guid>
{
    public Kopya() { }

    public Kopya(Guid kitapBaskiId, Guid kutuphaneId, string barkod,int count)
    {
        KitapBaskiId = kitapBaskiId;
        KutuphaneId = kutuphaneId;
        Barkod = barkod;
        Count = count;
    }

    public Guid KitapBaskiId { get; set; }
    public Guid KutuphaneId { get; set; }
    public string Barkod { get; set; }
    public int Count { get; set; }

    
    // Navigation
    public virtual KitapBaski KitapBaski { get; set; }
    public virtual Kutuphane Kutuphane { get; set; }
    public virtual ICollection<KopyaKonum> KopyalarKonumlar { get; set; } = new List<KopyaKonum>();
}