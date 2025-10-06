using NArchitecture.Core.Application.Responses;

namespace Application.Features.YayinEvis.Queries.GetById;

public class GetByIdYayinEviResponse : IResponse
{
    public Guid Id { get; set; }
    public string Adi { get; set; }
}