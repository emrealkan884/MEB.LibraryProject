using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IKopyaRepository : IAsyncRepository<Kopya, Guid>, IRepository<Kopya, Guid>
{
    Task<IPaginate<Kopya>> GetListWithRelationsAsync(int index = 0, int size = 10, CancellationToken cancellationToken = default);
}