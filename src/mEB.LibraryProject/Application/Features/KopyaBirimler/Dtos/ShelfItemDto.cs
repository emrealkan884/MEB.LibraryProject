namespace Application.Features.KopyaBirimler.Dtos;

public class ShelfItemDto
{
	public Guid KopyaBirimId { get; set; }
	public Guid KopyaId { get; set; }
	public string Barkod { get; set; } = null!;
	public int RafSira { get; set; }
}


