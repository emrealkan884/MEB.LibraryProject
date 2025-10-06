using NArchitecture.Core.Application.Responses;

namespace Application.Features.YayinEvis.Commands.Create;

public class CreatedYayinEviResponse : IResponse
{
    public Guid Id { get; set; }
    public string Adi { get; set; }
}