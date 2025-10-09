using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class YayinEvi : Entity<Guid>
{
    public YayinEvi() { }

    public YayinEvi(string adi)
    {
        Adi = adi;
    }

    public string Adi { get; set; }
    
    // Navigation simplified; editions (KitapBaski) reference YayinEvi directly
}