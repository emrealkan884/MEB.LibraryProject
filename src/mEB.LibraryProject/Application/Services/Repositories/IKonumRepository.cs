using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IKonumRepository : IAsyncRepository<Konum, Guid>, IRepository<Konum, Guid>
{
}