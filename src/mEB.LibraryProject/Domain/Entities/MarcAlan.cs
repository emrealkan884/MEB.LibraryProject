using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class MarcAlan : Entity<Guid>
{
	public MarcAlan() { }

	public MarcAlan(Guid marcKaydiId, string tag, string? ind1, string? ind2, string deger)
	{
		MarcKaydiId = marcKaydiId;
		Tag = tag;
		Ind1 = ind1;
		Ind2 = ind2;
		Deger = deger;
	}

	public Guid MarcKaydiId { get; set; }
	public string Tag { get; set; } = string.Empty;
	public string? Ind1 { get; set; }
	public string? Ind2 { get; set; }
	public string Deger { get; set; } = string.Empty;

	public virtual MarcKaydi MarcKaydi { get; set; } = null!;
}


