using MediatR;
using Application.Features.KopyaBirimler.Dtos;

namespace Application.Features.KopyaBirimler.Queries.ListShelfLayout;

public record ListShelfLayoutQuery(Guid KonumId) : IRequest<IReadOnlyList<ShelfItemDto>>;


