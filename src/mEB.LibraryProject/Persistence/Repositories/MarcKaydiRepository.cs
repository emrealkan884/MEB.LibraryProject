using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MarcKaydiRepository : EfRepositoryBase<MarcKaydi, Guid, BaseDbContext>, IMarcKaydiRepository
{
    public MarcKaydiRepository(BaseDbContext context) : base(context)
    {
    }
}


