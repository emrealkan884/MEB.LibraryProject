using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class KullaniciRepository : EfRepositoryBase<Kullanici, Guid, BaseDbContext>, IKullaniciRepository
{
    public KullaniciRepository(BaseDbContext context) : base(context)
    {
    }
}


