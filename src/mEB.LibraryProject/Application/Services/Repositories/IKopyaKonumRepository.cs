using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IKopyaKonumRepository : IAsyncRepository<KopyaKonum, Guid>, IRepository<KopyaKonum, Guid>
{
}