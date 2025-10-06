using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IEserYazarRepository : IAsyncRepository<EserYazar, Guid>, IRepository<EserYazar, Guid>
{
}