using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class KopyaBirim : Entity<Guid>
{
	public KopyaBirim() { }

	public KopyaBirim(Guid kopyaId, Guid kutuphaneId, Guid konumId, string barkod, int rafSira, OduncDurum durum)
	{
		KopyaId = kopyaId;
		KutuphaneId = kutuphaneId;
		KonumId = konumId;
		Barkod = barkod;
		RafSira = rafSira;
		Durum = durum;
	}

	public Guid KopyaId { get; set; }
	public Guid KutuphaneId { get; set; }
	public Guid KonumId { get; set; }

	public string Barkod { get; set; } = null!;
	public int RafSira { get; set; }
	public OduncDurum Durum { get; set; }

	// Navigation
	public virtual Kopya Kopya { get; set; } = null!;
	public virtual Kutuphane Kutuphane { get; set; } = null!;
	public virtual Konum Konum { get; set; } = null!;
}


