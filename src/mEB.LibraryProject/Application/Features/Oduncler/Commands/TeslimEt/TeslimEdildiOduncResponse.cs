using Domain.Enums;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Oduncler.Commands.TeslimEt;

public class TeslimEdildiOduncResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid KopyaId { get; set; }
    public Guid KullaniciId { get; set; }
    public DateTime? GercekTeslimTarihi { get; set; }
    public OduncDurum Durum { get; set; }
}