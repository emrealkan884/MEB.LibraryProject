using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class DeweySiniflama : Entity<Guid>
{
	public DeweySiniflama() { }

	public DeweySiniflama(string kod, string ad)
	{
		Kod = kod;
		Ad = ad;
	}

	public string Kod { get; set; } = string.Empty;
	public string Ad { get; set; } = string.Empty;
}


