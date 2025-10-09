using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class DijitalIcerik : Entity<Guid>
{
	//bir eserin birden çok dijital sürümü/formatı olur (PDF, ePub, ses, video)
	public DijitalIcerik() { }

	public DijitalIcerik(Guid eserId, string tur, string url):base()
	{
		EserId = eserId;
		Tur = tur;
		Url = url;
	}

	public Guid EserId { get; set; }
	public string Tur { get; set; } = string.Empty; // pdf, epub, audio, video
	public string Url { get; set; } = string.Empty;
}


