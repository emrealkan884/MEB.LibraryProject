using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IYayinEviRepository : IAsyncRepository<YayinEvi, Guid>, IRepository<YayinEvi, Guid>
{
}