using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Yazars.Queries.GetList;

public class GetListYazarListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Adi { get; set; }
    public string Soyadi { get; set; }
}