using Application.Features.Konumlar.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Konumlar;

public class KonumManager : IKonumService
{
    private readonly IKonumRepository _konumRepository;
    private readonly KonumBusinessRules _konumBusinessRules;

    public KonumManager(IKonumRepository konumRepository, KonumBusinessRules konumBusinessRules)
    {
        _konumRepository = konumRepository;
        _konumBusinessRules = konumBusinessRules;
    }

    public async Task<Konum?> GetAsync(
        Expression<Func<Konum, bool>> predicate,
        Func<IQueryable<Konum>, IIncludableQueryable<Konum, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Konum? konum = await _konumRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return konum;
    }

    public async Task<IPaginate<Konum>?> GetListAsync(
        Expression<Func<Konum, bool>>? predicate = null,
        Func<IQueryable<Konum>, IOrderedQueryable<Konum>>? orderBy = null,
        Func<IQueryable<Konum>, IIncludableQueryable<Konum, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Konum> konumList = await _konumRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return konumList;
    }

    public async Task<Konum> AddAsync(Konum konum)
    {
        Konum addedKonum = await _konumRepository.AddAsync(konum);

        return addedKonum;
    }

    public async Task<Konum> UpdateAsync(Konum konum)
    {
        Konum updatedKonum = await _konumRepository.UpdateAsync(konum);

        return updatedKonum;
    }

    public async Task<Konum> DeleteAsync(Konum konum, bool permanent = false)
    {
        Konum deletedKonum = await _konumRepository.DeleteAsync(konum);

        return deletedKonum;
    }
}
