using NArchitecture.Core.Application.Responses;

namespace Application.Features.Oduncs.Commands.Delete;

public class DeletedOduncResponse : IResponse
{
    public Guid Id { get; set; }
}