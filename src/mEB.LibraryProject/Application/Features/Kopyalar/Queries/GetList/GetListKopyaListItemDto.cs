using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Kopyalar.Queries.GetList;

public class GetListKopyaListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid KitapId { get; set; }
    public Guid KutuphaneId { get; set; }
    public string Barkod { get; set; }
    public Kitap Kitap { get; set; }
    //public Kutuphane Kutuphane { get; set; }
}