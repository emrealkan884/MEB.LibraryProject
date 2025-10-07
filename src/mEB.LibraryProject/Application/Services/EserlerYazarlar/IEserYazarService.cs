using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.EserlerYazarlar;

public interface IEserYazarService
{
    Task<EserYazar?> GetAsync(
        Expression<Func<EserYazar, bool>> predicate,
        Func<IQueryable<EserYazar>, IIncludableQueryable<EserYazar, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<EserYazar>?> GetListAsync(
        Expression<Func<EserYazar, bool>>? predicate = null,
        Func<IQueryable<EserYazar>, IOrderedQueryable<EserYazar>>? orderBy = null,
        Func<IQueryable<EserYazar>, IIncludableQueryable<EserYazar, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<EserYazar> AddAsync(EserYazar eserYazar);
    Task<EserYazar> UpdateAsync(EserYazar eserYazar);
    Task<EserYazar> DeleteAsync(EserYazar eserYazar, bool permanent = false);
}
