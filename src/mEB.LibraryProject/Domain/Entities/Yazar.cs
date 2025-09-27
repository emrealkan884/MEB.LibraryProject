using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Yazar : Entity<Guid>
{
    public string Ad { get; set; }
    public string Soyad { get; set; }
}
