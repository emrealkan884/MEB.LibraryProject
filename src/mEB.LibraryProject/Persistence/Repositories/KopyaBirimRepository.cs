using System;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class KopyaBirimRepository : EfRepositoryBase<KopyaBirim, Guid, BaseDbContext>, IKopyaBirimRepository
{
	public KopyaBirimRepository(BaseDbContext context) : base(context) { }
}


