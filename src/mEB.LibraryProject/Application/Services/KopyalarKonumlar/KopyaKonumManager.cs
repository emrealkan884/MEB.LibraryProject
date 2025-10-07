using Application.Features.KopyalarKonumlar.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.KopyalarKonumlar;

public class KopyaKonumManager : IKopyaKonumService
{
    private readonly IKopyaKonumRepository _kopyaKonumRepository;
    private readonly KopyaKonumBusinessRules _kopyaKonumBusinessRules;

    public KopyaKonumManager(IKopyaKonumRepository kopyaKonumRepository, KopyaKonumBusinessRules kopyaKonumBusinessRules)
    {
        _kopyaKonumRepository = kopyaKonumRepository;
        _kopyaKonumBusinessRules = kopyaKonumBusinessRules;
    }

    public async Task<KopyaKonum?> GetAsync(
        Expression<Func<KopyaKonum, bool>> predicate,
        Func<IQueryable<KopyaKonum>, IIncludableQueryable<KopyaKonum, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        KopyaKonum? kopyaKonum = await _kopyaKonumRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return kopyaKonum;
    }

    public async Task<IPaginate<KopyaKonum>?> GetListAsync(
        Expression<Func<KopyaKonum, bool>>? predicate = null,
        Func<IQueryable<KopyaKonum>, IOrderedQueryable<KopyaKonum>>? orderBy = null,
        Func<IQueryable<KopyaKonum>, IIncludableQueryable<KopyaKonum, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<KopyaKonum> kopyaKonumList = await _kopyaKonumRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return kopyaKonumList;
    }

    public async Task<KopyaKonum> AddAsync(KopyaKonum kopyaKonum)
    {
        KopyaKonum addedKopyaKonum = await _kopyaKonumRepository.AddAsync(kopyaKonum);

        return addedKopyaKonum;
    }

    public async Task<KopyaKonum> UpdateAsync(KopyaKonum kopyaKonum)
    {
        KopyaKonum updatedKopyaKonum = await _kopyaKonumRepository.UpdateAsync(kopyaKonum);

        return updatedKopyaKonum;
    }

    public async Task<KopyaKonum> DeleteAsync(KopyaKonum kopyaKonum, bool permanent = false)
    {
        KopyaKonum deletedKopyaKonum = await _kopyaKonumRepository.DeleteAsync(kopyaKonum);

        return deletedKopyaKonum;
    }
}
