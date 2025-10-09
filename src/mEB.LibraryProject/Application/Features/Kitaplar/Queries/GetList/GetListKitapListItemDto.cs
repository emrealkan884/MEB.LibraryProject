using Domain.Enums;
using NArchitecture.Core.Application.Dtos;


public class GetListKitapListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Adi { get; set; }
    public string DilKodu { get; set; }
    public string? Aciklama { get; set; }
    public string DeweyKodu { get; set; }
    public string MarcVerisi { get; set; }
    public string? IlkBaskiISBN {get;set;}
    public string? IlkBaskiBilgisi  {get;set;}
    public EserKategorisi Kategori { get; set; }
    public List<string>? YazarAdları { get; set; }
}