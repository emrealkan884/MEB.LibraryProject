using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Kullanici : Entity<Guid>
{
    public Kullanici() { }

    public Kullanici(string adSoyad, string eposta, string sifre, KullaniciRol rol, string? telefon = null)
    {
        AdSoyad = adSoyad;
        Eposta = eposta;
        Sifre = sifre;
        Rol = rol;
        Telefon = telefon;
    }

    public string AdSoyad { get; set; }
    public string Eposta { get; set; }
    public string Sifre { get; set; }
    public string? Telefon { get; set; }
    public KullaniciRol Rol { get; set; } // Yetki seviyesi

    // Navigation
    public ICollection<Rezerve> RezerveKayitlari { get; set; } = new List<Rezerve>();
    public ICollection<Odunc> OduncKayitlari { get; set; } = new List<Odunc>();
}