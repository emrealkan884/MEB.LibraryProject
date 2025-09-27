using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Kopya: Entity<Guid>
{
    public Guid KitapId { get; set; }
    public Guid KutuphaneId { get; set; }
    public string Barkod { get; set; }
    
}
