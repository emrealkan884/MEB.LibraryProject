using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Rules;

namespace Application.Features.KopyaBirimler.Rules;

public class KopyaBirimBusinessRules : BaseBusinessRules
{
	private readonly DbContext _db;
	public KopyaBirimBusinessRules(DbContext db) { _db = db; }

	public async Task EnsureBarcodeUnique(string barkod, CancellationToken ct)
	{
		bool exists = await _db.Set<KopyaBirim>().AnyAsync(x => x.Barkod == barkod, ct);
		if (exists) throw new InvalidOperationException("Barkod zaten kayıtlı.");
	}
}


