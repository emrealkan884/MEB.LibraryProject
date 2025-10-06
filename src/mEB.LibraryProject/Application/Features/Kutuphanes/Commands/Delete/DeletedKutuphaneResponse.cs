using NArchitecture.Core.Application.Responses;

namespace Application.Features.Kutuphanes.Commands.Delete;

public class DeletedKutuphaneResponse : IResponse
{
    public Guid Id { get; set; }
}