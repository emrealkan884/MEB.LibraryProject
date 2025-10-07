using NArchitecture.Core.Application.Responses;

namespace Application.Features.Kitaplar.Commands.Delete;

public class DeletedKitapResponse : IResponse
{
    public Guid Id { get; set; }
}