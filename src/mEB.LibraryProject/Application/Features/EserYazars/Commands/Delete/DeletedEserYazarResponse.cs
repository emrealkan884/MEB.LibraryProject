using NArchitecture.Core.Application.Responses;

namespace Application.Features.EserYazars.Commands.Delete;

public class DeletedEserYazarResponse : IResponse
{
    public Guid Id { get; set; }
}