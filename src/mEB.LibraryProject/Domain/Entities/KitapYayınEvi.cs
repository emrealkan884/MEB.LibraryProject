using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class KitapYayınEvi : Entity<Guid>
{
    public KitapYayınEvi() { }

    public KitapYayınEvi(Guid kitapId, Guid yayinEviId)
    {
        KitapId = kitapId;
        YayinEviId = yayinEviId;
    }

    public Guid KitapId { get; set; }
    public Guid YayinEviId { get; set; }

    // Navigation
    public virtual Kitap Kitap { get; set; }
    public virtual YayinEvi YayinEvi { get; set; }
}