using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Eserler.Queries.GetList;

public class GetListEserListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Adi { get; set; }
    public string DilKodu { get; set; }
    public string Aciklama { get; set; }
    public string? DeweyKodu { get; set; }
    public string? MarcVerisi { get; set; }
    public string Kategori { get; set; }
    public string EserTipi { get; set; }
    public List<string> YazarAdlari { get; set; } = new();
}