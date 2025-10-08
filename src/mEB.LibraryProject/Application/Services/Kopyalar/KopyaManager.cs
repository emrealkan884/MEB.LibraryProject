using Application.Features.Kopyalar.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Kopyalar;

public class KopyaManager : IKopyaService
{
    private readonly IKopyaRepository _kopyaRepository;
    private readonly KopyaBusinessRules _kopyaBusinessRules;

    public KopyaManager(IKopyaRepository kopyaRepository, KopyaBusinessRules kopyaBusinessRules)
    {
        _kopyaRepository = kopyaRepository;
        _kopyaBusinessRules = kopyaBusinessRules;
    }

    public async Task<Kopya?> GetAsync(
        Expression<Func<Kopya, bool>> predicate,
        Func<IQueryable<Kopya>, IIncludableQueryable<Kopya, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Kopya? kopya = await _kopyaRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return kopya;
    }

    public async Task<IPaginate<Kopya>?> GetListAsync(
        Expression<Func<Kopya, bool>>? predicate = null,
        Func<IQueryable<Kopya>, IOrderedQueryable<Kopya>>? orderBy = null,
        Func<IQueryable<Kopya>, IIncludableQueryable<Kopya, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Kopya> kopyaList = await _kopyaRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return kopyaList;
    }

    public async Task<Kopya> AddAsync(Kopya kopya)
    {
        Kopya addedKopya = await _kopyaRepository.AddAsync(kopya);

        return addedKopya;
    }
    public async Task<Kopya> AddOrIncrementAsync(Kopya kopya)
    {
        var existingKopya = await _kopyaRepository.GetAsync(
            k => k.Barkod == kopya.Barkod && k.KutuphaneId == kopya.KutuphaneId,
            enableTracking: true
        );

        if (existingKopya is not null)
        {
            existingKopya.Count += kopya.Count;
            existingKopya.UpdatedDate = DateTime.UtcNow;
            await _kopyaRepository.UpdateAsync(existingKopya);
            return existingKopya;
        }

        return await _kopyaRepository.AddAsync(kopya);
    }
    public async Task<Kopya> UpdateAsync(Kopya kopya)
    {
        Kopya updatedKopya = await _kopyaRepository.UpdateAsync(kopya);

        return updatedKopya;
    }

    public async Task<Kopya> DeleteAsync(Kopya kopya, bool permanent = false)
    {
        Kopya deletedKopya = await _kopyaRepository.DeleteAsync(kopya);

        return deletedKopya;
    }
    
    public async Task<IPaginate<Kopya>> GetListWithRelationsAsync(int index = 0, int size = 10)
    {
        return await _kopyaRepository.GetListWithRelationsAsync(index, size);
    }
}
