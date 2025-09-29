using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Rezerve : Entity<Guid>
{
    public Rezerve() { }

    public Rezerve(Guid kullaniciId, Guid eserId, Guid kutuphaneId, DateTime talepZamani, DateTime sonGecerlilikTarihi)
    {
        KullaniciId = kullaniciId;
        EserId = eserId;
        KutuphaneId = kutuphaneId;
        RezerveDurum = RezerveDurum.Bekliyor;
        TalepZamani = talepZamani;
        SonGecerlilikTarihi = sonGecerlilikTarihi;
    }

    public Guid? KopyaId { get; set; } // Onay sırasında atanacak kopya
    public Guid EserId { get; set; } // Rezervasyon yapılan eser
    public Guid KutuphaneId { get; set; } // Kullanıcının seçtiği kütüphane
    public Guid KullaniciId { get; set; } // Rezervasyonu yapan kullanıcı
    public RezerveDurum RezerveDurum { get; set; } // Rezervasyon durumu
    public DateTime TalepZamani { get; set; } // Rezervasyon talep zamanı
    public DateTime SonGecerlilikTarihi { get; set; } // Rezervasyon geçerlilik süresi

    // Navigation
    public Kopya? Kopya { get; set; } // Onaylanan kopya
    public Kitap Eser { get; set; } // Eser bilgisi
    public Kutuphane Kutuphane { get; set; } // Kütüphane bilgisi
    public Kullanici Kullanici { get; set; } // Rezervasyonu yapan kullanıcı

    #region Is Mantigi Ornek

    /*
        using (var transaction = db.Database.BeginTransaction())
        {
            var rezerve = db.Rezerveler.SingleOrDefault(r => r.Id == rezerveId);

            if (rezerve == null)
                throw new Exception("Rezervasyon bulunamadı");

            var uygunKopya = db.Kopyalar
                .Where(k => k.KitapId == rezerve.EserId &&
                            k.KutuphaneId == rezerve.KutuphaneId &&
                            !db.Odunclar.Any(o => o.KopyaId == k.Id && o.Durum == OduncDurum.Aktif))
                .FirstOrDefault();

            if (uygunKopya == null)
                throw new Exception("Uygun kopya bulunamadı");

            // Rezervasyonu güncelle
            rezerve.KopyaId = uygunKopya.Id;
            rezerve.RezerveDurum = RezerveDurum.Onaylandi;

            // Ödünç kaydı oluştur
            var odunc = new Odunc
            {
                KopyaId = uygunKopya.Id,
                KullaniciId = rezerve.KullaniciId,
                KutuphaneId = rezerve.KutuphaneId,
                OduncAlmaTarihi = DateTime.Now,
                Durum = OduncDurum.Aktif
            };

            db.Odunclar.Add(odunc);
            db.SaveChanges();

            transaction.Commit();
        }
     */

    #endregion
}