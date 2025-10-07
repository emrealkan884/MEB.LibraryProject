using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Kopya : Entity<Guid>
{
    public Kopya() { }

    public Kopya(Guid kitapId, Guid kutuphaneId, string barkod,int count)
    {
        KitapId = kitapId;
        KutuphaneId = kutuphaneId;
        Barkod = barkod;
        Count = count;
    }

    public Guid KitapId { get; set; }
    public Guid KutuphaneId { get; set; }
    public string Barkod { get; set; }
    public int Count { get; set; }

    
    // Navigation
    public virtual Kitap Kitap { get; set; }
    public virtual Kutuphane Kutuphane { get; set; }
    public virtual ICollection<KopyaKonum> KopyalarKonumlar { get; set; } = new List<KopyaKonum>();
}