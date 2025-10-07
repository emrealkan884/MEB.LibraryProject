using NArchitecture.Core.Application.Responses;

namespace Application.Features.Kopyalar.Commands.Delete;

public class DeletedKopyaResponse : IResponse
{
    public Guid Id { get; set; }
}