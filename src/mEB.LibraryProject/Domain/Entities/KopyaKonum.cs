namespace Domain.Entities;

public class KopyaKonum
{
    public Guid Id { get; set; }
    
    public Guid KopyaId { get; set; }
    public Kopya Kopya { get; set; }

    public Guid KonumId { get; set; }
    public Konum Konum { get; set; }

    public Guid KutuphaneId { get; set; }
    public Kutuphane Kutuphane { get; set; }

    public int Adet { get; set; } = 1; // Bu konumda kaç kopya var
}
