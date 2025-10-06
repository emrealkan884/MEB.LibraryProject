using NArchitecture.Core.Application.Dtos;
using Domain.Enums;

namespace Application.Features.Oduncs.Queries.GetList;

public class GetListOduncListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid KopyaId { get; set; }
    public Guid KullaniciId { get; set; }
    public Guid KutuphaneId { get; set; }
    public DateTime OduncAlmaTarihi { get; set; }
    public DateTime SonTeslimTarihi { get; set; }
    public DateTime? GercekTeslimTarihi { get; set; }
    public OduncDurum Durum { get; set; }
    //public Kopya Kopya { get; set; }
    //public Kullanici Kullanici { get; set; }
    //public Kutuphane Kutuphane { get; set; }
}