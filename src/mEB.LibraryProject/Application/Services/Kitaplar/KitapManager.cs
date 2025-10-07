using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Paging;
using System.Linq.Expressions;

namespace Application.Services.Kitaplar;

public class KitapManager : IKitapService
{
    private readonly IKitapRepository _kitapRepository;
    private readonly KitapBusinessRules _kitapBusinessRules;

    public KitapManager(IKitapRepository kitapRepository, KitapBusinessRules kitapBusinessRules)
    {
        _kitapRepository = kitapRepository;
        _kitapBusinessRules = kitapBusinessRules;
    }

    public async Task<Kitap?> GetAsync(
        Expression<Func<Kitap, bool>> predicate,
        Func<IQueryable<Kitap>, IIncludableQueryable<Kitap, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Kitap? kitap =
            await _kitapRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return kitap;
    }

    public async Task<IPaginate<Kitap>?> GetListAsync(
        Expression<Func<Kitap, bool>>? predicate = null,
        Func<IQueryable<Kitap>, IOrderedQueryable<Kitap>>? orderBy = null,
        Func<IQueryable<Kitap>, IIncludableQueryable<Kitap, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Kitap> kitapList = await _kitapRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return kitapList;
    }

    public async Task<Kitap> AddAsync(Kitap kitap)
    {
        Kitap addedKitap = await _kitapRepository.AddAsync(kitap);

        return addedKitap;
    }

    public async Task<Kitap> UpdateAsync(Kitap kitap)
    {
        Kitap updatedKitap = await _kitapRepository.UpdateAsync(kitap);

        return updatedKitap;
    }

    public async Task<Kitap> DeleteAsync(Kitap kitap, bool permanent = false)
    {
        Kitap deletedKitap = await _kitapRepository.DeleteAsync(kitap);

        return deletedKitap;
    }
}