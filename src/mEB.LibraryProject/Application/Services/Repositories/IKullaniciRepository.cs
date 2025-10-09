using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IKullaniciRepository : IAsyncRepository<Kullanici, Guid>, IRepository<Kullanici, Guid>
{
}


