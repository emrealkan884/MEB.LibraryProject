using MediatR;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Application.Features.KopyaBirimler.Dtos;

namespace Application.Features.KopyaBirimler.Commands.Move;

public class MoveKopyaBirimCommandHandler : IRequestHandler<MoveKopyaBirimCommand, KopyaBirimDto>
{
	private readonly DbContext _db;
	private readonly IMapper _mapper;

	public MoveKopyaBirimCommandHandler(DbContext db, IMapper mapper) { _db = db; _mapper = mapper; }

	public async Task<KopyaBirimDto> Handle(MoveKopyaBirimCommand request, CancellationToken ct)
	{
		var birim = await _db.Set<KopyaBirim>().FirstOrDefaultAsync(x => x.Id == request.KopyaBirimId, ct);
		if (birim is null) throw new InvalidOperationException("Kopya birim bulunamadı.");

		await _db.Set<KopyaBirim>()
			.Where(x => x.KonumId == birim.KonumId && x.RafSira > birim.RafSira)
			.ExecuteUpdateAsync(s => s.SetProperty(x => x.RafSira, x => x.RafSira - 1), ct);

		birim.KonumId = request.YeniKonumId;

		if (request.YeniRafSira is int hedef)
		{
			await _db.Set<KopyaBirim>()
				.Where(x => x.KonumId == request.YeniKonumId && x.RafSira >= hedef)
				.ExecuteUpdateAsync(s => s.SetProperty(x => x.RafSira, x => x.RafSira + 1), ct);
			birim.RafSira = hedef;
		}
		else
		{
			int max = await _db.Set<KopyaBirim>()
				.Where(x => x.KonumId == request.YeniKonumId)
				.Select(x => (int?)x.RafSira).MaxAsync(ct) ?? 0;
			birim.RafSira = max + 1;
		}

		await _db.SaveChangesAsync(ct);
		return _mapper.Map<KopyaBirimDto>(birim);
	}
}


