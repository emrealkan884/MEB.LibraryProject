using NArchitecture.Core.Application.Responses;

namespace Application.Features.Yazarlar.Queries.GetById;

public class GetByIdYazarResponse : IResponse
{
    public Guid Id { get; set; }
    public string Adi { get; set; }
    public string Soyadi { get; set; }
}