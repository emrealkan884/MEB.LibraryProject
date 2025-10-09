using Domain.Entities;
using Domain.Enums;

public class Kitap : Eser
{
    public Kitap() { }

    public Kitap(string adi, string dilkodu, string aciklama, string deweyKodu, string marcVerisi,
        EserKategorisi kategori )
        : base(adi, dilkodu, aciklama, deweyKodu, marcVerisi,EserTipi.Kitap, kategori)
    {
    }

    // Edition-specific fields moved to KitapBaski

    // Navigation
    public virtual ICollection<KitapBaski> Baskilar { get; set; } = new List<KitapBaski>();
}