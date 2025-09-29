using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Yazar : Entity<Guid>
{
    public Yazar() { }

    public Yazar(string adi, string soyadi)
    {
        Adi = adi;
        Soyadi = soyadi;
    }
    
    public string Adi { get; set; }
    public string Soyadi { get; set; }

    // Navigation
    public ICollection<EserYazar> EserYazarlar { get; set; } = new List<EserYazar>();
}
