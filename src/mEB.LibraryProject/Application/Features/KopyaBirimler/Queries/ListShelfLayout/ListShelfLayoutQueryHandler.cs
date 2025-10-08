using MediatR;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Application.Features.KopyaBirimler.Dtos;

namespace Application.Features.KopyaBirimler.Queries.ListShelfLayout;

public class ListShelfLayoutQueryHandler : IRequestHandler<ListShelfLayoutQuery, IReadOnlyList<ShelfItemDto>>
{
	private readonly DbContext _db;
	public ListShelfLayoutQueryHandler(DbContext db) { _db = db; }

	public async Task<IReadOnlyList<ShelfItemDto>> Handle(ListShelfLayoutQuery request, CancellationToken ct)
	{
		return await _db.Set<KopyaBirim>()
			.Where(n => n.KonumId == request.KonumId)
			.OrderBy(n => n.RafSira)
			.Select(n => new ShelfItemDto { KopyaBirimId = n.Id, Barkod = n.Barkod, RafSira = n.RafSira, KopyaId = n.KopyaId })
			.ToListAsync(ct);
	}
}


