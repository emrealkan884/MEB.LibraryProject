using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class KopyaKonum : Entity<Guid>
{
    public KopyaKonum()
    {
    }

    public KopyaKonum(Guid kopyaId, Guid konumId, Guid kutuphaneId, int adet)
    {
        KopyaId = kopyaId;
        KonumId = konumId;
        KutuphaneId = kutuphaneId;
        Adet = adet;
    }

    public Guid KopyaId { get; set; }
    public Guid KonumId { get; set; }
    public Guid KutuphaneId { get; set; }
    public int Adet { get; set; } = 1; // Bu konumda kaç kopya var


    //Navigation
    public virtual Kopya Kopya { get; set; }
    public virtual Konum Konum { get; set; }
    public virtual Kutuphane Kutuphane { get; set; }
}