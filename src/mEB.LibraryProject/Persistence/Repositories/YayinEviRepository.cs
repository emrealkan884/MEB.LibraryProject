using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class YayinEviRepository : EfRepositoryBase<YayinEvi, Guid, BaseDbContext>, IYayinEviRepository
{
    public YayinEviRepository(BaseDbContext context) : base(context)
    {
    }
}