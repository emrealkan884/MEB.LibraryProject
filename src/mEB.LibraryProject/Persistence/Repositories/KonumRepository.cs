using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class KonumRepository : EfRepositoryBase<Konum, Guid, BaseDbContext>, IKonumRepository
{
    public KonumRepository(BaseDbContext context) : base(context)
    {
    }
}