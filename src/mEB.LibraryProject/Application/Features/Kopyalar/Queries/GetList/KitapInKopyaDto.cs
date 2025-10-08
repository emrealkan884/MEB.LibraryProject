using Domain.Enums;

namespace Application.Features.Kopyalar.Queries.GetList;

public class KitapInKopyaDto
{
    public Guid Id { get; set; }
    public string Adi { get; set; }
    public string DilKodu { get; set; }
    public string? Aciklama { get; set; }
    public string DeweyKodu { get; set; }
    public string MarcVerisi { get; set; }
    public string ISBN {get;set;}
    public string? SayfaSayisi  { get; set; }
    public short? BasimYili {get;set;}
    public string? BasimYeri {get;set;}
    public string? BaskiBilgisi  {get;set;}
    public EserKategorisi Kategori { get; set; }
    public List<string>? YazarAdları { get; set; }
}