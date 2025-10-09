using MediatR;

namespace Application.Features.KitapBaskilar.Queries.GetList;

public class GetListKitapBaskiQuery : IRequest<IReadOnlyList<GetListKitapBaskiItemDto>>
{
    public class Handler : IRequestHandler<GetListKitapBaskiQuery, IReadOnlyList<GetListKitapBaskiItemDto>>
    {
        public Task<IReadOnlyList<GetListKitapBaskiItemDto>> Handle(GetListKitapBaskiQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult<IReadOnlyList<GetListKitapBaskiItemDto>>(Array.Empty<GetListKitapBaskiItemDto>());
        }
    }
}

