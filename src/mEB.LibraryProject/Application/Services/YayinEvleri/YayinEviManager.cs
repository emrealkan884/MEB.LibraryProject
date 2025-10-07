using Application.Features.YayinEvleri.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.YayinEvleri;

public class YayinEviManager : IYayinEviService
{
    private readonly IYayinEviRepository _yayinEviRepository;
    private readonly YayinEviBusinessRules _yayinEviBusinessRules;

    public YayinEviManager(IYayinEviRepository yayinEviRepository, YayinEviBusinessRules yayinEviBusinessRules)
    {
        _yayinEviRepository = yayinEviRepository;
        _yayinEviBusinessRules = yayinEviBusinessRules;
    }

    public async Task<YayinEvi?> GetAsync(
        Expression<Func<YayinEvi, bool>> predicate,
        Func<IQueryable<YayinEvi>, IIncludableQueryable<YayinEvi, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        YayinEvi? yayinEvi = await _yayinEviRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return yayinEvi;
    }

    public async Task<IPaginate<YayinEvi>?> GetListAsync(
        Expression<Func<YayinEvi, bool>>? predicate = null,
        Func<IQueryable<YayinEvi>, IOrderedQueryable<YayinEvi>>? orderBy = null,
        Func<IQueryable<YayinEvi>, IIncludableQueryable<YayinEvi, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<YayinEvi> yayinEviList = await _yayinEviRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return yayinEviList;
    }

    public async Task<YayinEvi> AddAsync(YayinEvi yayinEvi)
    {
        YayinEvi addedYayinEvi = await _yayinEviRepository.AddAsync(yayinEvi);

        return addedYayinEvi;
    }

    public async Task<YayinEvi> UpdateAsync(YayinEvi yayinEvi)
    {
        YayinEvi updatedYayinEvi = await _yayinEviRepository.UpdateAsync(yayinEvi);

        return updatedYayinEvi;
    }

    public async Task<YayinEvi> DeleteAsync(YayinEvi yayinEvi, bool permanent = false)
    {
        YayinEvi deletedYayinEvi = await _yayinEviRepository.DeleteAsync(yayinEvi);

        return deletedYayinEvi;
    }
}
