using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Konumlar;

public interface IKonumService
{
    Task<Konum?> GetAsync(
        Expression<Func<Konum, bool>> predicate,
        Func<IQueryable<Konum>, IIncludableQueryable<Konum, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Konum>?> GetListAsync(
        Expression<Func<Konum, bool>>? predicate = null,
        Func<IQueryable<Konum>, IOrderedQueryable<Konum>>? orderBy = null,
        Func<IQueryable<Konum>, IIncludableQueryable<Konum, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Konum> AddAsync(Konum konum);
    Task<Konum> UpdateAsync(Konum konum);
    Task<Konum> DeleteAsync(Konum konum, bool permanent = false);
}
