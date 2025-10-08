using MediatR;
using AutoMapper;
using Domain.Entities;
using Application.Features.KopyaBirimler.Dtos;
using Application.Features.KopyaBirimler.Rules;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.KopyaBirimler.Commands.Create;

public class CreateKopyaBirimCommandHandler : IRequestHandler<CreateKopyaBirimCommand, KopyaBirimDto>
{
	private readonly DbContext _db;
	private readonly IMapper _mapper;
	private readonly KopyaBirimBusinessRules _rules;

	public CreateKopyaBirimCommandHandler(DbContext db, IMapper mapper, KopyaBirimBusinessRules rules)
	{
		_db = db; _mapper = mapper; _rules = rules;
	}

	public async Task<KopyaBirimDto> Handle(CreateKopyaBirimCommand request, CancellationToken ct)
	{
		await _rules.EnsureBarcodeUnique(request.Barkod, ct);

		int rafSira = request.RafSira ?? (await _db.Set<KopyaBirim>()
			.Where(n => n.KonumId == request.KonumId)
			.Select(n => (int?)n.RafSira).MaxAsync(ct) ?? 0) + 1;

		var birim = new KopyaBirim(request.KopyaId, request.KutuphaneId, request.KonumId, request.Barkod, rafSira, Domain.Enums.OduncDurum.Musait);
		_db.Set<KopyaBirim>().Add(birim);
		await _db.SaveChangesAsync(ct);

		return _mapper.Map<KopyaBirimDto>(birim);
	}
}


