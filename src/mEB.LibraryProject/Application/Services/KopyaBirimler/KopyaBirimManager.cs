using Application.Features.KopyaBirimler.Dtos;
using Application.Features.KopyaBirimler.Commands.Create;
using Application.Features.KopyaBirimler.Commands.Move;
using Application.Features.KopyaBirimler.Commands.UpdateStatus;
using Application.Features.KopyaBirimler.Queries.GetByBarcode;
using Application.Features.KopyaBirimler.Queries.ListShelfLayout;
using MediatR;

namespace Application.Services.KopyaBirimler;

public class KopyaBirimManager : IKopyaBirimService
{
	private readonly IMediator _mediator;
	public KopyaBirimManager(IMediator mediator) { _mediator = mediator; }

	public Task<KopyaBirimDto> CreateAsync(Guid kopyaId, Guid kutuphaneId, Guid konumId, string barkod, int? rafSira, CancellationToken ct)
		=> _mediator.Send(new CreateKopyaBirimCommand(kopyaId, kutuphaneId, konumId, barkod, rafSira), ct);

	public Task<KopyaBirimDto> MoveAsync(Guid kopyaBirimId, Guid yeniKonumId, int? yeniRafSira, CancellationToken ct)
		=> _mediator.Send(new MoveKopyaBirimCommand(kopyaBirimId, yeniKonumId, yeniRafSira), ct);

	public Task<IReadOnlyList<ShelfItemDto>> ListShelfAsync(Guid konumId, CancellationToken ct)
		=> _mediator.Send(new ListShelfLayoutQuery(konumId), ct);

	public Task<KopyaBirimDto?> GetByBarcodeAsync(string barkod, CancellationToken ct)
		=> _mediator.Send(new GetKopyaBirimByBarcodeQuery(barkod), ct);

	public Task<KopyaBirimDto> UpdateStatusAsync(Guid kopyaBirimId, Domain.Enums.OduncDurum yeniDurum, CancellationToken ct)
		=> _mediator.Send(new UpdateKopyaBirimStatusCommand(kopyaBirimId, yeniDurum), ct);
}


