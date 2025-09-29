using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class EserYazar : Entity<Guid>
{
    public EserYazar() { }

    public EserYazar(Guid yazarId, Guid eserId)
    {
        YazarId = yazarId;
        EserId = eserId;
    }

    public Guid EserId { get; set; }
    public Guid YazarId { get; set; }

    // Navigation
    public virtual Eser Eser { get; set; }
    public virtual Yazar Yazar { get; set; }
}