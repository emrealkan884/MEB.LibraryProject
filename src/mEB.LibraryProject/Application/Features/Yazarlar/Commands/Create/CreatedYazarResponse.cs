using NArchitecture.Core.Application.Responses;

namespace Application.Features.Yazarlar.Commands.Create;

public class CreatedYazarResponse : IResponse
{
    public Guid Id { get; set; }
    public string Adi { get; set; }
    public string Soyadi { get; set; }
}