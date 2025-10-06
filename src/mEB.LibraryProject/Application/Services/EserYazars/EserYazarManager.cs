using Application.Features.EserYazars.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.EserYazars;

public class EserYazarManager : IEserYazarService
{
    private readonly IEserYazarRepository _eserYazarRepository;
    private readonly EserYazarBusinessRules _eserYazarBusinessRules;

    public EserYazarManager(IEserYazarRepository eserYazarRepository, EserYazarBusinessRules eserYazarBusinessRules)
    {
        _eserYazarRepository = eserYazarRepository;
        _eserYazarBusinessRules = eserYazarBusinessRules;
    }

    public async Task<EserYazar?> GetAsync(
        Expression<Func<EserYazar, bool>> predicate,
        Func<IQueryable<EserYazar>, IIncludableQueryable<EserYazar, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        EserYazar? eserYazar = await _eserYazarRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return eserYazar;
    }

    public async Task<IPaginate<EserYazar>?> GetListAsync(
        Expression<Func<EserYazar, bool>>? predicate = null,
        Func<IQueryable<EserYazar>, IOrderedQueryable<EserYazar>>? orderBy = null,
        Func<IQueryable<EserYazar>, IIncludableQueryable<EserYazar, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<EserYazar> eserYazarList = await _eserYazarRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return eserYazarList;
    }

    public async Task<EserYazar> AddAsync(EserYazar eserYazar)
    {
        EserYazar addedEserYazar = await _eserYazarRepository.AddAsync(eserYazar);

        return addedEserYazar;
    }

    public async Task<EserYazar> UpdateAsync(EserYazar eserYazar)
    {
        EserYazar updatedEserYazar = await _eserYazarRepository.UpdateAsync(eserYazar);

        return updatedEserYazar;
    }

    public async Task<EserYazar> DeleteAsync(EserYazar eserYazar, bool permanent = false)
    {
        EserYazar deletedEserYazar = await _eserYazarRepository.DeleteAsync(eserYazar);

        return deletedEserYazar;
    }
}
