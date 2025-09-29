using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;


public class Kullanici : Entity<Guid>
{
    public Kullanici() { }

    public Kullanici(string adSoyad, string eposta, string sifre, string telefon = null)
    {
        AdSoyad = adSoyad;
        Eposta = eposta;
        Sifre = sifre;
        Telefon = telefon;
    }

    public string AdSoyad { get; set; }
    public string Eposta { get; set; }
    public string Sifre { get; set; }    
    public string? Telefon { get; set; }

    // Navigation
    public ICollection<Rezerve> RezerveKayitlari { get; set; } = new List<Rezerve>();
    public ICollection<Odunc> OduncKayitlari { get; set; } = new List<Odunc>();
}