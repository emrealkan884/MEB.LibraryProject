using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Oduncs;

public interface IOduncService
{
    Task<Odunc?> GetAsync(
        Expression<Func<Odunc, bool>> predicate,
        Func<IQueryable<Odunc>, IIncludableQueryable<Odunc, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Odunc>?> GetListAsync(
        Expression<Func<Odunc, bool>>? predicate = null,
        Func<IQueryable<Odunc>, IOrderedQueryable<Odunc>>? orderBy = null,
        Func<IQueryable<Odunc>, IIncludableQueryable<Odunc, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Odunc> AddAsync(Odunc odunc);
    Task<Odunc> UpdateAsync(Odunc odunc);
    Task<Odunc> DeleteAsync(Odunc odunc, bool permanent = false);
}
