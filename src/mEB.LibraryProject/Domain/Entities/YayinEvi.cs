using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class YayinEvi : Entity<Guid>
{
    public string YayinEviAdi { get; set; }
}
