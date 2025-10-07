using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IKitapRepository : IAsyncRepository<Kitap, Guid>, IRepository<Kitap, Guid>
{
}