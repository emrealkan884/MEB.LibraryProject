using NArchitecture.Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IKitapBaskiRepository : IAsyncRepository<KitapBaski, Guid>, IRepository<KitapBaski, Guid>
{
}


