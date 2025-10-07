using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Kopyalar;

public interface IKopyaService
{
    Task<Kopya?> GetAsync(
        Expression<Func<Kopya, bool>> predicate,
        Func<IQueryable<Kopya>, IIncludableQueryable<Kopya, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Kopya>?> GetListAsync(
        Expression<Func<Kopya, bool>>? predicate = null,
        Func<IQueryable<Kopya>, IOrderedQueryable<Kopya>>? orderBy = null,
        Func<IQueryable<Kopya>, IIncludableQueryable<Kopya, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Kopya> AddAsync(Kopya kopya);
    Task<Kopya> UpdateAsync(Kopya kopya);
    Task<Kopya> DeleteAsync(Kopya kopya, bool permanent = false);
}
