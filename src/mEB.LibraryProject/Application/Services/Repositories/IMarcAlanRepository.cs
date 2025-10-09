using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IMarcAlanRepository : IAsyncRepository<MarcAlan, Guid>, IRepository<MarcAlan, Guid>
{
}


