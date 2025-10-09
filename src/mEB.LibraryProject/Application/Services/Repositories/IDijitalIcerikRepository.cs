using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IDijitalIcerikRepository : IAsyncRepository<DijitalIcerik, Guid>, IRepository<DijitalIcerik, Guid>
{
}


