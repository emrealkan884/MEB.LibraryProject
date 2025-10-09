using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

//Çoka çok ilişkiyi normalde efcore otomatik olarak yapıyor (Default Convention). 
//Bizim ara tablo için bir entity oluşturmamıza gerek yok. Ancak o ara tabloya farklı propertyler eklemek istersek  oluşturmamız lazım.
public class EserYazar : Entity<Guid>
{
    //Farklı proplar
    
    public EserYazar() { }

    public EserYazar(Guid yazarId, Guid eserId)
    {
        YazarId = yazarId;
        EserId = eserId; 
    }

    public Guid EserId { get; set; }
    public Guid YazarId { get; set; }

    // Navigation property
    public virtual Eser Eser { get; set; }
    public virtual Yazar Yazar { get; set; }
    
}