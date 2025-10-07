using Application.Features.Eserler.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Eserler;

public class EserManager : IEserService
{
    private readonly IEserRepository _eserRepository;
    private readonly EserBusinessRules _eserBusinessRules;

    public EserManager(IEserRepository eserRepository, EserBusinessRules eserBusinessRules)
    {
        _eserRepository = eserRepository;
        _eserBusinessRules = eserBusinessRules;
    }

    public async Task<Eser?> GetAsync(
        Expression<Func<Eser, bool>> predicate,
        Func<IQueryable<Eser>, IIncludableQueryable<Eser, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Eser? eser = await _eserRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return eser;
    }

    public async Task<IPaginate<Eser>?> GetListAsync(
        Expression<Func<Eser, bool>>? predicate = null,
        Func<IQueryable<Eser>, IOrderedQueryable<Eser>>? orderBy = null,
        Func<IQueryable<Eser>, IIncludableQueryable<Eser, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Eser> eserList = await _eserRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return eserList;
    }

    public async Task<Eser> AddAsync(Eser eser)
    {
        Eser addedEser = await _eserRepository.AddAsync(eser);

        return addedEser;
    }

    public async Task<Eser> UpdateAsync(Eser eser)
    {
        Eser updatedEser = await _eserRepository.UpdateAsync(eser);

        return updatedEser;
    }

    public async Task<Eser> DeleteAsync(Eser eser, bool permanent = false)
    {
        Eser deletedEser = await _eserRepository.DeleteAsync(eser);

        return deletedEser;
    }
}