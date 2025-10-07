using NArchitecture.Core.Application.Responses;

namespace Application.Features.YayinEvleri.Commands.Delete;

public class DeletedYayinEviResponse : IResponse
{
    public Guid Id { get; set; }
}