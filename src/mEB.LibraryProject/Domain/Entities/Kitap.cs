namespace Domain.Entities;
public class Kitap : Eser
{
    public string ISBN { get; set; }
    public string SayfaSayisi { get; set; }
    public string YayinEviId { get; set; }
    public Guid YazarId { get; set; }
    public short BasimYili { get; set; }
    public string BasimYeri { get; set; }
    public string BaskiBilgisi { get; set; }//2. Baskı
}
