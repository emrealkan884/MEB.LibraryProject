using NArchitecture.Core.Application.Responses;

namespace Application.Features.Kopyas.Commands.Delete;

public class DeletedKopyaResponse : IResponse
{
    public Guid Id { get; set; }
}