using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Odunc : Entity<Guid>
{
    public Odunc() { }

    public Odunc(Guid kopyaId, Guid kullaniciId, Guid kutuphaneId, DateTime oduncAlmaTarihi, DateTime? iadeTarihi = null)
    {
        KopyaId = kopyaId;
        KullaniciId = kullaniciId;
        KutuphaneId = kutuphaneId;
        OduncAlmaTarihi = oduncAlmaTarihi;
        IadeTarihi = iadeTarihi;
        Durum = OduncDurum.Aktif;
    }

    public Guid KopyaId { get; set; }
    public Guid KullaniciId { get; set; }
    public Guid KutuphaneId { get; set; }
    public DateTime OduncAlmaTarihi { get; set; }
    public DateTime? IadeTarihi { get; set; }
    public OduncDurum Durum { get; set; }

    // Navigation
    public Kopya Kopya { get; set; }
    public Kullanici Kullanici { get; set; }
    public Kutuphane Kutuphane { get; set; }
}