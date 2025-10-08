namespace Application.Features.KopyaBirimler.Dtos;

public class KopyaBirimDto
{
	public Guid Id { get; set; }
	public string Barkod { get; set; } = null!;
	public Guid KopyaId { get; set; }
	public Guid KutuphaneId { get; set; }
	public Guid KonumId { get; set; }
	public int RafSira { get; set; }
	public string Durum { get; set; } = null!;
}


