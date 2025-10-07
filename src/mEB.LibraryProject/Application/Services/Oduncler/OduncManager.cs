using Application.Features.Oduncler.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Oduncler;

public class OduncManager : IOduncService
{
    private readonly IOduncRepository _oduncRepository;
    private readonly OduncBusinessRules _oduncBusinessRules;

    public OduncManager(IOduncRepository oduncRepository, OduncBusinessRules oduncBusinessRules)
    {
        _oduncRepository = oduncRepository;
        _oduncBusinessRules = oduncBusinessRules;
    }

    public async Task<Odunc?> GetAsync(
        Expression<Func<Odunc, bool>> predicate,
        Func<IQueryable<Odunc>, IIncludableQueryable<Odunc, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Odunc? odunc = await _oduncRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return odunc;
    }

    public async Task<IPaginate<Odunc>?> GetListAsync(
        Expression<Func<Odunc, bool>>? predicate = null,
        Func<IQueryable<Odunc>, IOrderedQueryable<Odunc>>? orderBy = null,
        Func<IQueryable<Odunc>, IIncludableQueryable<Odunc, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Odunc> oduncList = await _oduncRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return oduncList;
    }

    public async Task<Odunc> AddAsync(Odunc odunc)
    {
        Odunc addedOdunc = await _oduncRepository.AddAsync(odunc);

        return addedOdunc;
    }

    public async Task<Odunc> UpdateAsync(Odunc odunc)
    {
        Odunc updatedOdunc = await _oduncRepository.UpdateAsync(odunc);

        return updatedOdunc;
    }

    public async Task<Odunc> DeleteAsync(Odunc odunc, bool permanent = false)
    {
        Odunc deletedOdunc = await _oduncRepository.DeleteAsync(odunc);

        return deletedOdunc;
    }
}
