using Domain.Entities;
using Domain.Enums;

public class Kitap : Eser
{
    public Kitap() { }

    public Kitap(string adi, string dilkodu, string aciklama, string deweyKodu, string marcVerisi,
        string isbn, string sayfaSayisi,
        short basimYili, string basimYeri, string baskiBilgisi)
        : base(adi, dilkodu, aciklama, deweyKodu, marcVerisi,EserTipi.Kitap)
    {
        ISBN = isbn;
        SayfaSayisi = sayfaSayisi;
        BasimYili = basimYili;
        BasimYeri = basimYeri;
        BaskiBilgisi = baskiBilgisi;
    }
    public string ISBN { get; set; }
    public string SayfaSayisi { get; set; }
    public short BasimYili { get; set; }
    public string BasimYeri { get; set; }
    public string BaskiBilgisi { get; set; } //2. Baski

    // Navigation
    public virtual ICollection<KitapYayınEvi> KitapsYayinEvis { get; set; } = new List<KitapYayınEvi>();
    public virtual ICollection<Kopya> Kopyalar { get; set; } = new List<Kopya>();
}