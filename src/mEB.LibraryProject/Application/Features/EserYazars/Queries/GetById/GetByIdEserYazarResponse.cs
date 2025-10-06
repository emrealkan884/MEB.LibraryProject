using NArchitecture.Core.Application.Responses;

namespace Application.Features.EserYazars.Queries.GetById;

public class GetByIdEserYazarResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid EserId { get; set; }
    public Guid YazarId { get; set; }
    //public Eser Eser { get; set; }
    //public Yazar Yazar { get; set; }
}