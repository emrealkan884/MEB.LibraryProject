using NArchitecture.Core.Application.Responses;

namespace Application.Features.Yazars.Queries.GetById;

public class GetByIdYazarResponse : IResponse
{
    public Guid Id { get; set; }
    public string Adi { get; set; }
    public string Soyadi { get; set; }
}