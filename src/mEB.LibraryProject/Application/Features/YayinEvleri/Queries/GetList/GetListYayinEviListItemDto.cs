using NArchitecture.Core.Application.Dtos;

namespace Application.Features.YayinEvleri.Queries.GetList;

public class GetListYayinEviListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Adi { get; set; }
}