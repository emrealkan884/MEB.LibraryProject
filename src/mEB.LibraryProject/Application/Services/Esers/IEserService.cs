using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Esers;

public interface IEserService
{
    Task<Eser?> GetAsync(
        Expression<Func<Eser, bool>> predicate,
        Func<IQueryable<Eser>, IIncludableQueryable<Eser, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Eser>?> GetListAsync(
        Expression<Func<Eser, bool>>? predicate = null,
        Func<IQueryable<Eser>, IOrderedQueryable<Eser>>? orderBy = null,
        Func<IQueryable<Eser>, IIncludableQueryable<Eser, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Eser> AddAsync(Eser eser);
    Task<Eser> UpdateAsync(Eser eser);
    Task<Eser> DeleteAsync(Eser eser, bool permanent = false);
}
