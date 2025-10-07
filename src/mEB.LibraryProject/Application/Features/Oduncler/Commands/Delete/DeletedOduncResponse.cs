using NArchitecture.Core.Application.Responses;

namespace Application.Features.Oduncler.Commands.Delete;

public class DeletedOduncResponse : IResponse
{
    public Guid Id { get; set; }
}