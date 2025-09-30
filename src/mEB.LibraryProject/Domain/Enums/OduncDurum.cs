namespace Domain.Enums;

public enum OduncDurum
{
    Musait = 0,  
    RezerveEdildi = 1,   // Ayrıldı ama teslim edilmedi
    OduncVerildi = 2,    // Kullanıcıya verildi
    TeslimAlindi = 3,    // İade edildi (kayıt kapandı)
    IptalEdildi = 4      // Rezervasyon iptal
}