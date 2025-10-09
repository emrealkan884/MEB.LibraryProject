using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class KitapBaskiRepository : EfRepositoryBase<KitapBaski, Guid, BaseDbContext>, IKitapBaskiRepository
{
    public KitapBaskiRepository(BaseDbContext context) : base(context)
    {
    }
}


