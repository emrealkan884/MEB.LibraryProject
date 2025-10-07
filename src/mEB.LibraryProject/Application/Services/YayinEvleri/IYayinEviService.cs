using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.YayinEvleri;

public interface IYayinEviService
{
    Task<YayinEvi?> GetAsync(
        Expression<Func<YayinEvi, bool>> predicate,
        Func<IQueryable<YayinEvi>, IIncludableQueryable<YayinEvi, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<YayinEvi>?> GetListAsync(
        Expression<Func<YayinEvi, bool>>? predicate = null,
        Func<IQueryable<YayinEvi>, IOrderedQueryable<YayinEvi>>? orderBy = null,
        Func<IQueryable<YayinEvi>, IIncludableQueryable<YayinEvi, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<YayinEvi> AddAsync(YayinEvi yayinEvi);
    Task<YayinEvi> UpdateAsync(YayinEvi yayinEvi);
    Task<YayinEvi> DeleteAsync(YayinEvi yayinEvi, bool permanent = false);
}
