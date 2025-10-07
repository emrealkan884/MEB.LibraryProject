using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Paging;
using System.Linq.Expressions;

namespace Application.Services.Kitaplar;
public interface IKitapService
{
     Task<Kitap?> GetAsync(
        Expression<Func<Kitap, bool>> predicate,
        Func<IQueryable<Kitap>, IIncludableQueryable<Kitap, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Kitap>?> GetListAsync(
        Expression<Func<Kitap, bool>>? predicate = null,
        Func<IQueryable<Kitap>, IOrderedQueryable<Kitap>>? orderBy = null,
        Func<IQueryable<Kitap>, IIncludableQueryable<Kitap, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Kitap> AddAsync(Kitap kitap);
    Task<Kitap> UpdateAsync(Kitap kitap);
    Task<Kitap> DeleteAsync(Kitap kitap, bool permanent = false);
}