using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IOduncRepository : IAsyncRepository<Odunc, Guid>, IRepository<Odunc, Guid>
{
}