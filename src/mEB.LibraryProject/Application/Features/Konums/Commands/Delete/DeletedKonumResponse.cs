using NArchitecture.Core.Application.Responses;

namespace Application.Features.Konums.Commands.Delete;

public class DeletedKonumResponse : IResponse
{
    public Guid Id { get; set; }
}