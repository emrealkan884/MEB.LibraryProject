using MediatR;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Application.Features.KopyaBirimler.Dtos;

namespace Application.Features.KopyaBirimler.Commands.UpdateStatus;

public class UpdateKopyaBirimStatusCommandHandler : IRequestHandler<UpdateKopyaBirimStatusCommand, KopyaBirimDto>
{
	private readonly DbContext _db;
	private readonly IMapper _mapper;

	public UpdateKopyaBirimStatusCommandHandler(DbContext db, IMapper mapper) { _db = db; _mapper = mapper; }

	public async Task<KopyaBirimDto> Handle(UpdateKopyaBirimStatusCommand request, CancellationToken ct)
	{
		var birim = await _db.Set<KopyaBirim>().FirstOrDefaultAsync(x => x.Id == request.KopyaBirimId, ct)
			?? throw new InvalidOperationException("Kopya birim bulunamadı.");

		birim.Durum = request.YeniDurum;
		await _db.SaveChangesAsync(ct);

		return _mapper.Map<KopyaBirimDto>(birim);
	}
}


