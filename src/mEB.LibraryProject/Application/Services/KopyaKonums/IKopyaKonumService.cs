using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.KopyaKonums;

public interface IKopyaKonumService
{
    Task<KopyaKonum?> GetAsync(
        Expression<Func<KopyaKonum, bool>> predicate,
        Func<IQueryable<KopyaKonum>, IIncludableQueryable<KopyaKonum, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<KopyaKonum>?> GetListAsync(
        Expression<Func<KopyaKonum, bool>>? predicate = null,
        Func<IQueryable<KopyaKonum>, IOrderedQueryable<KopyaKonum>>? orderBy = null,
        Func<IQueryable<KopyaKonum>, IIncludableQueryable<KopyaKonum, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<KopyaKonum> AddAsync(KopyaKonum kopyaKonum);
    Task<KopyaKonum> UpdateAsync(KopyaKonum kopyaKonum);
    Task<KopyaKonum> DeleteAsync(KopyaKonum kopyaKonum, bool permanent = false);
}
