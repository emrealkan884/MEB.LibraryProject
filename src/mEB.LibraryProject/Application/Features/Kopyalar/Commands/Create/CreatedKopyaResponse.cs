using NArchitecture.Core.Application.Responses;

namespace Application.Features.Kopyalar.Commands.Create;

public class CreatedKopyaResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid KitapBaskiId { get; set; }
    public Guid KutuphaneId { get; set; }
    public string Barkod { get; set; }
    public Kitap Kitap { get; set; }

    public int Count { get; set; }
    //public Kutuphane Kutuphane { get; set; }
}