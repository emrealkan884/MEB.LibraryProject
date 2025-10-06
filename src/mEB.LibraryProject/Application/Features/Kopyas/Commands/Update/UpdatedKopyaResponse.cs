using NArchitecture.Core.Application.Responses;

namespace Application.Features.Kopyas.Commands.Update;

public class UpdatedKopyaResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid KitapId { get; set; }
    public Guid KutuphaneId { get; set; }
    public string Barkod { get; set; }
    public Kitap Kitap { get; set; }
    //public Kutuphane Kutuphane { get; set; }
}