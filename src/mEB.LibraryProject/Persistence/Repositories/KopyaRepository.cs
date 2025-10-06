using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class KopyaRepository : EfRepositoryBase<Kopya, Guid, BaseDbContext>, IKopyaRepository
{
    public KopyaRepository(BaseDbContext context) : base(context)
    {
    }
}