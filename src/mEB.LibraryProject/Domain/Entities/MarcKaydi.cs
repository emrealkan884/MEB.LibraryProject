using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class MarcKaydi : Entity<Guid>
{
	public MarcKaydi() { }

	public MarcKaydi(string isbn, string baslik, string yazarlik, string yayinYeri, string yayinTarihi)
	{
		Isbn = isbn;
		Baslik = baslik;
		Yazarlik = yazarlik;
		YayinYeri = yayinYeri;
		YayinTarihi = yayinTarihi;
	}

	public string Isbn { get; set; } = string.Empty;
	public string Baslik { get; set; } = string.Empty;
	public string Yazarlik { get; set; } = string.Empty;
	public string YayinYeri { get; set; } = string.Empty;
	public string YayinTarihi { get; set; } = string.Empty;

	public virtual ICollection<MarcAlan> Alanlar { get; set; } = new List<MarcAlan>();
}


