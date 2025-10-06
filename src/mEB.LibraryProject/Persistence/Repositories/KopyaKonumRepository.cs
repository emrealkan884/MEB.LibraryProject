using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class KopyaKonumRepository : EfRepositoryBase<KopyaKonum, Guid, BaseDbContext>, IKopyaKonumRepository
{
    public KopyaKonumRepository(BaseDbContext context) : base(context)
    {
    }
}