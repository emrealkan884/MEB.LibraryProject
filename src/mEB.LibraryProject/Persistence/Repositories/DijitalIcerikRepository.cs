using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DijitalIcerikRepository : EfRepositoryBase<DijitalIcerik, Guid, BaseDbContext>, IDijitalIcerikRepository
{
    public DijitalIcerikRepository(BaseDbContext context) : base(context)
    {
    }
}


