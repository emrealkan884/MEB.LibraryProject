using MediatR;
using Application.Features.KopyaBirimler.Dtos;

namespace Application.Features.KopyaBirimler.Commands.Move;

public record MoveKopyaBirimCommand(Guid KopyaBirimId, Guid YeniKonumId, int? YeniRafSira) : IRequest<KopyaBirimDto>;


