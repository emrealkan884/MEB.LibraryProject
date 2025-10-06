using NArchitecture.Core.Application.Dtos;

namespace Application.Features.EserYazars.Queries.GetList;

public class GetListEserYazarListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid EserId { get; set; }
    public Guid YazarId { get; set; }
    public string EserAdi { get; set; }
    public string YazarAdi { get; set; }
    public string YazarSoyadi { get; set; }
}