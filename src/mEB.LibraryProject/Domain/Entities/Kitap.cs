using Domain.Entities;

public class Kitap : Eser
{
    public Kitap() { }

    public Kitap(string adi, string dilkodu, string aciklama, string deweyKodu, string marcVerisi,
        string isbn, string sayfaSayisi, Guid yayinEviId,
        short basimYili, string basimYeri, string baskiBilgisi)
        : base(adi, dilkodu, aciklama, deweyKodu, marcVerisi)
    {
        ISBN = isbn;
        SayfaSayisi = sayfaSayisi;
        YayinEviId = yayinEviId;
        BasimYili = basimYili;
        BasimYeri = basimYeri;
        BaskiBilgisi = baskiBilgisi;
    }

    public string ISBN { get; set; }
    public string SayfaSayisi { get; set; }
    public Guid YayinEviId { get; set; }
    public short BasimYili { get; set; }
    public string BasimYeri { get; set; }
    public string BaskiBilgisi { get; set; } //2. Baski

    // Navigation
    public YayinEvi YayinEvi { get; set; }
    public ICollection<Kopya> Kopyalar { get; set; } = new List<Kopya>();
}