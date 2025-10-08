using MediatR;
using Application.Features.KopyaBirimler.Dtos;

namespace Application.Features.KopyaBirimler.Commands.Create;

public record CreateKopyaBirimCommand(Guid KopyaId, Guid KutuphaneId, Guid KonumId, string Barkod, int? RafSira) : IRequest<KopyaBirimDto>;


