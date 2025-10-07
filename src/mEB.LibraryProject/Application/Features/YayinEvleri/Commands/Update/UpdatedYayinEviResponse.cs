using NArchitecture.Core.Application.Responses;

namespace Application.Features.YayinEvleri.Commands.Update;

public class UpdatedYayinEviResponse : IResponse
{
    public Guid Id { get; set; }
    public string Adi { get; set; }
}