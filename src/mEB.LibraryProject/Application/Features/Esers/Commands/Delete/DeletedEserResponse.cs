using NArchitecture.Core.Application.Responses;

namespace Application.Features.Esers.Commands.Delete;

public class DeletedEserResponse : IResponse
{
    public Guid Id { get; set; }
}