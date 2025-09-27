using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Kutuphane : Entity<Guid>
{
    public string KutuphaneAdi { get; set; }
    public string Adres { get; set; }
    public KurumTuru KurumTuru { get; set; }
    public Guid? UstKutuphaneId { get; set; }

}
