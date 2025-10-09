using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Persistence.Paging;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class KopyaRepository : EfRepositoryBase<Kopya, Guid, BaseDbContext>, IKopyaRepository
{
    public KopyaRepository(BaseDbContext context) : base(context)
    {
    }

    public async Task<IPaginate<Kopya>> GetListWithRelationsAsync(int index = 0, int size = 10, CancellationToken cancellationToken = default)
    {
        return await Context.Kopyalar
            .Include(k => k.KitapBaski)
                .ThenInclude(b => b.Kitap)
                    .ThenInclude(k => k.EserlerYazarlar)
                        .ThenInclude(ey => ey.Yazar)
            .Include(k => k.KitapBaski)
                .ThenInclude(b => b.YayinEvi)
            .ToPaginateAsync(index, size, cancellationToken: cancellationToken);
    }
}