using MediatR;
using Application.Features.KopyaBirimler.Dtos;
using Domain.Enums;

namespace Application.Features.KopyaBirimler.Commands.UpdateStatus;

public record UpdateKopyaBirimStatusCommand(Guid KopyaBirimId, OduncDurum YeniDurum) : IRequest<KopyaBirimDto>;


