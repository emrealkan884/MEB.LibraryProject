using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Konum : Entity<Guid>
{
    public Konum() { }

    public Konum(Guid kutuphaneId, Guid? ustKonumId, KonumTip konumTip, string ad)
    {
        KutuphaneId = kutuphaneId;
        UstKonumId = ustKonumId;
        KonumTip = konumTip;
        Ad = ad;
    }

    public Guid KutuphaneId { get; set; }
    public Guid? UstKonumId { get; set; }
    public KonumTip KonumTip { get; set; }
    public string Ad { get; set; }

    // Navigation
    public virtual Kutuphane Kutuphane { get; set; }
    public virtual Konum? UstKonum { get; set; }
    public virtual ICollection<Konum> AltKonumlar { get; set; } = new List<Konum>();
    public virtual ICollection<KopyaKonum> KopyaKonumlar { get; set; } = new List<KopyaKonum>();
}