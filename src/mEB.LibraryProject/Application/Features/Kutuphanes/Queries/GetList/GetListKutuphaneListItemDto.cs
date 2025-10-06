using NArchitecture.Core.Application.Dtos;
using Domain.Enums;

namespace Application.Features.Kutuphanes.Queries.GetList;

public class GetListKutuphaneListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Adi { get; set; }
    public string Adres { get; set; }
    public KurumTuru KurumTuru { get; set; }
    public Guid? UstKutuphaneId { get; set; }
    public string UstKutuphaneAdi { get; set; }
    //public Kutuphane? UstKutuphane { get; set; }
}