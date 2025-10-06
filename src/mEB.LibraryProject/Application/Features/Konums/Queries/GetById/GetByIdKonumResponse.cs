using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.Konums.Queries.GetById;

public class GetByIdKonumResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid KutuphaneId { get; set; }
    public Guid? UstKonumId { get; set; }
    public KonumTip KonumTip { get; set; }
    public string Ad { get; set; }
    //public Konum? UstKonum { get; set; }
    //public Kutuphane Kutuphane { get; set; }
}