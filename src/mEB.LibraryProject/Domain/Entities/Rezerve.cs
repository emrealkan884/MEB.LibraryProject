using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Rezerve : Entity<Guid>
{
    public Guid KopyaId { get; set; }
    public Guid EserId { get; set; }
    public Guid KutuphaneId { get; set; }
    public Durum Durum { get; set; }
    public DateTime TalepZamani { get; set; }
    public DateTime SonGecerlilikTarihi { get; set; }
}
