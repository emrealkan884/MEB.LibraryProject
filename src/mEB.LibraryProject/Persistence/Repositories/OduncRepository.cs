using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class OduncRepository : EfRepositoryBase<Odunc, Guid, BaseDbContext>, IOduncRepository
{
    public OduncRepository(BaseDbContext context) : base(context)
    {
    }
}