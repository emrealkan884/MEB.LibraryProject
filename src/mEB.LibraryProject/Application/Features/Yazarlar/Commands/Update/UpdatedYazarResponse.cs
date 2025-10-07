using NArchitecture.Core.Application.Responses;

namespace Application.Features.Yazarlar.Commands.Update;

public class UpdatedYazarResponse : IResponse
{
    public Guid Id { get; set; }
    public string Adi { get; set; }
    public string Soyadi { get; set; }
}