using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IEserRepository : IAsyncRepository<Eser, Guid>, IRepository<Eser, Guid>
{
}