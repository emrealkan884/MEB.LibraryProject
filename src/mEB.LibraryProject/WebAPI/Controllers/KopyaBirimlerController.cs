using Microsoft.AspNetCore.Mvc;
using Application.Services.KopyaBirimler;
using Application.Features.KopyaBirimler.Dtos;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class KopyaBirimlerController : ControllerBase
{
	private readonly IKopyaBirimService _service;
	public KopyaBirimlerController(IKopyaBirimService service) { _service = service; }

	[HttpPost]
	public Task<KopyaBirimDto> Create([FromBody] CreateRequest r, CancellationToken ct)
		=> _service.CreateAsync(r.KopyaId, r.KutuphaneId, r.KonumId, r.Barkod, r.RafSira, ct);

	[HttpPost("{id:guid}/move")]
	public Task<KopyaBirimDto> Move(Guid id, [FromBody] MoveRequest r, CancellationToken ct)
		=> _service.MoveAsync(id, r.YeniKonumId, r.YeniRafSira, ct);

	[HttpPatch("{id:guid}/status")]
	public Task<KopyaBirimDto> UpdateStatus(Guid id, [FromBody] UpdateStatusRequest r, CancellationToken ct)
		=> _service.UpdateStatusAsync(id, r.YeniDurum, ct);

	[HttpGet("by-barcode/{barkod}")]
	public Task<KopyaBirimDto?> GetByBarcode(string barkod, CancellationToken ct)
		=> _service.GetByBarcodeAsync(barkod, ct);

	[HttpGet("shelf/{konumId:guid}")]
	public Task<IReadOnlyList<ShelfItemDto>> ListShelf(Guid konumId, CancellationToken ct)
		=> _service.ListShelfAsync(konumId, ct);
}

public record CreateRequest(Guid KopyaId, Guid KutuphaneId, Guid KonumId, string Barkod, int? RafSira);
public record MoveRequest(Guid YeniKonumId, int? YeniRafSira);
public record UpdateStatusRequest(Domain.Enums.OduncDurum YeniDurum);


