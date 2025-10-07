using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class KitapRepository : EfRepositoryBase<Kitap,Guid,BaseDbContext>,IKitapRepository
{
    public KitapRepository(BaseDbContext context) : base(context)
    {
    }
}