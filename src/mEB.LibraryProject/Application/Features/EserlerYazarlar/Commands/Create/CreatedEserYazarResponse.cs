using NArchitecture.Core.Application.Responses;

namespace Application.Features.EserlerYazarlar.Commands.Create;

public class CreatedEserYazarResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid EserId { get; set; }
    public string? EserAdi { get; set; }
    public Guid YazarId { get; set; }
    public string? YazarAdi { get; set; }
    public string? YazarSoyadi { get; set; }
}