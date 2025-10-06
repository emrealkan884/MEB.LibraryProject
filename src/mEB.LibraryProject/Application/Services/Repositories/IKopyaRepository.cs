using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IKopyaRepository : IAsyncRepository<Kopya, Guid>, IRepository<Kopya, Guid>
{
}