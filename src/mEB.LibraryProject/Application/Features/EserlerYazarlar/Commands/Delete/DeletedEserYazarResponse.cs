using NArchitecture.Core.Application.Responses;

namespace Application.Features.EserlerYazarlar.Commands.Delete;

public class DeletedEserYazarResponse : IResponse
{
    public Guid Id { get; set; }
}