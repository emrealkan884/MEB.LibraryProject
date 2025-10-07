using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.Kutuphaneler.Commands.Update;

public class UpdatedKutuphaneResponse : IResponse
{
    public Guid Id { get; set; }
    public string Adi { get; set; }
    public string Adres { get; set; }
    public KurumTuru KurumTuru { get; set; }
    public Guid? UstKutuphaneId { get; set; }
    //public Kutuphane? UstKutuphane { get; set; }
}