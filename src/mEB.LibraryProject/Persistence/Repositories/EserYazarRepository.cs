using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class EserYazarRepository : EfRepositoryBase<EserYazar, Guid, BaseDbContext>, IEserYazarRepository
{
    public EserYazarRepository(BaseDbContext context) : base(context)
    {
    }
}