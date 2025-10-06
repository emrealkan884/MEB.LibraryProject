using NArchitecture.Core.Application.Responses;

namespace Application.Features.Yazars.Commands.Delete;

public class DeletedYazarResponse : IResponse
{
    public Guid Id { get; set; }
}