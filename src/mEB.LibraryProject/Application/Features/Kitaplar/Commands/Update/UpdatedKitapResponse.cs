using NArchitecture.Core.Application.Responses;


public class UpdatedKitapResponse : IResponse
{
    public Guid Id { get; set; }
    public string Adi { get; set; }
    public string DilKodu { get; set; }
    public string Aciklama { get; set; }
    public string? DeweyKodu { get; set; }
    public string? MarcVerisi { get; set; }
}