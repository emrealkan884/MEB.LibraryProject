using NArchitecture.Core.Application.Responses;

namespace Application.Features.KopyalarKonumlar.Queries.GetById;

public class GetByIdKopyaKonumResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid KopyaId { get; set; }
    public Guid KonumId { get; set; }
    public Guid KutuphaneId { get; set; }
    public int Adet { get; set; }
    //public Kopya Kopya { get; set; }
    //public Konum Konum { get; set; }
    //public Kutuphane Kutuphane { get; set; }
}