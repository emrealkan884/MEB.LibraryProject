using NArchitecture.Core.Application.Responses;

namespace Application.Features.EserlerYazarlar.Commands.Update;

public class UpdatedEserYazarResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid EserId { get; set; }
    public Guid YazarId { get; set; }
    //public Eser Eser { get; set; }
    //public Yazar Yazar { get; set; }
}