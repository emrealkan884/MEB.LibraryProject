using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class KitapYayinEvi : Entity<Guid>
{
    public KitapYayinEvi() { }

    public KitapYayinEvi(Guid kitapId, Guid yayinEviId)
    {
        KitapId = kitapId;
        YayinEviId = yayinEviId;
    }

    public Guid KitapId { get; set; }
    public Guid YayinEviId { get; set; }

    // Legacy join entity kept for backward compatibility
}