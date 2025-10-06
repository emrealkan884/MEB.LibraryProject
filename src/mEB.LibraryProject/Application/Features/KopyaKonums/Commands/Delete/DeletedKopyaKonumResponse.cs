using NArchitecture.Core.Application.Responses;

namespace Application.Features.KopyaKonums.Commands.Delete;

public class DeletedKopyaKonumResponse : IResponse
{
    public Guid Id { get; set; }
}