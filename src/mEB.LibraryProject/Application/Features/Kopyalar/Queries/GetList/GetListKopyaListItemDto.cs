using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Kopyalar.Queries.GetList;

public class GetListKopyaListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid KitapBaskiId { get; set; }
    public Guid KutuphaneId { get; set; }
    public string Barkod { get; set; }
    public KitapInKopyaDto Kitap { get; set; }
    //public Kutuphane Kutuphane { get; set; }
}