using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Yazarlar.Queries.GetList;

public class GetListYazarListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Adi { get; set; }
    public string Soyadi { get; set; }
}