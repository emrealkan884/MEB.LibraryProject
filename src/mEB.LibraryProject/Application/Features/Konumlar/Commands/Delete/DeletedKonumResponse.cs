using NArchitecture.Core.Application.Responses;

namespace Application.Features.Konumlar.Commands.Delete;

public class DeletedKonumResponse : IResponse
{
    public Guid Id { get; set; }
}