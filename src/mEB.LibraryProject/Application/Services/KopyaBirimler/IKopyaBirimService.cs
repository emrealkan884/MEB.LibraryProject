using Application.Features.KopyaBirimler.Dtos;

namespace Application.Services.KopyaBirimler;

public interface IKopyaBirimService
{
	Task<KopyaBirimDto> CreateAsync(Guid kopyaId, Guid kutuphaneId, Guid konumId, string barkod, int? rafSira, CancellationToken ct);
	Task<KopyaBirimDto> MoveAsync(Guid kopyaBirimId, Guid yeniKonumId, int? yeniRafSira, CancellationToken ct);
	Task<IReadOnlyList<ShelfItemDto>> ListShelfAsync(Guid konumId, CancellationToken ct);
	Task<KopyaBirimDto?> GetByBarcodeAsync(string barkod, CancellationToken ct);
	Task<KopyaBirimDto> UpdateStatusAsync(Guid kopyaBirimId, Domain.Enums.OduncDurum yeniDurum, CancellationToken ct);
}


