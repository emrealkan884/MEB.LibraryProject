using NArchitecture.Core.Application.Responses;

namespace Application.Features.Eserler.Commands.Create;

public class CreatedEserResponse : IResponse
{
    public Guid Id { get; set; }
    public string Adi { get; set; }
    public string DilKodu { get; set; }
    public string Aciklama { get; set; }
    public string? DeweyKodu { get; set; }
    public string? MarcVerisi { get; set; }
}