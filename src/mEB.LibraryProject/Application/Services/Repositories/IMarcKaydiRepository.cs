using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IMarcKaydiRepository : IAsyncRepository<MarcKaydi, Guid>, IRepository<MarcKaydi, Guid>
{
}


