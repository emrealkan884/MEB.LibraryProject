using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Eser : Entity<Guid>
{
    public string EserAdi { get; set; }
    public string DilKodu { get; set; }
    public string Aciklama { get; set; }
}
