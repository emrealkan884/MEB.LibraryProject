using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class EserRepository : EfRepositoryBase<Eser, Guid, BaseDbContext>, IEserRepository
{
    public EserRepository(BaseDbContext context) : base(context)
    {
    }
}