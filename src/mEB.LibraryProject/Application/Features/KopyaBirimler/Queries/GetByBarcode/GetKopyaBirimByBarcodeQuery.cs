using MediatR;
using Application.Features.KopyaBirimler.Dtos;

namespace Application.Features.KopyaBirimler.Queries.GetByBarcode;

public record GetKopyaBirimByBarcodeQuery(string Barkod) : IRequest<KopyaBirimDto?>;


