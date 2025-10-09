using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MarcAlanRepository : EfRepositoryBase<MarcAlan, Guid, BaseDbContext>, IMarcAlanRepository
{
    public MarcAlanRepository(BaseDbContext context) : base(context)
    {
    }
}


