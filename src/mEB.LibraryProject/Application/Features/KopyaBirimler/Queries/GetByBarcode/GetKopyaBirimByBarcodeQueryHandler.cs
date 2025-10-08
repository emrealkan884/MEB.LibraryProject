using MediatR;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Application.Features.KopyaBirimler.Dtos;
using AutoMapper;

namespace Application.Features.KopyaBirimler.Queries.GetByBarcode;

public class GetKopyaBirimByBarcodeQueryHandler : IRequestHandler<GetKopyaBirimByBarcodeQuery, KopyaBirimDto?>
{
	private readonly DbContext _db;
	private readonly IMapper _mapper;

	public GetKopyaBirimByBarcodeQueryHandler(DbContext db, IMapper mapper) { _db = db; _mapper = mapper; }

	public async Task<KopyaBirimDto?> Handle(GetKopyaBirimByBarcodeQuery request, CancellationToken ct)
	{
		var entity = await _db.Set<KopyaBirim>().FirstOrDefaultAsync(x => x.Barkod == request.Barkod, ct);
		return entity is null ? null : _mapper.Map<KopyaBirimDto>(entity);
	}
}


