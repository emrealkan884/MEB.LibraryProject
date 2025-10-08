using System;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IKopyaBirimRepository : IAsyncRepository<KopyaBirim, Guid>, IRepository<KopyaBirim, Guid>
{
}


