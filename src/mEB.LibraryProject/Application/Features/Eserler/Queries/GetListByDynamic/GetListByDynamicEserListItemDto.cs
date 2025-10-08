namespace Application.Features.Eserler.Queries.GetListByDynamic;

public class GetListByDynamicEserListItemDto
{
    public Guid Id { get; set; }
    public string Adi { get; set; }
    public string DilKodu { get; set; }
    public string? Aciklama { get; set; }
    public string Kategori { get; set; }
    public string EserTipi { get; set; } // Kitap, Dergi, Video vs.
    public List<string> YazarAdları { get; set; } = new();
}