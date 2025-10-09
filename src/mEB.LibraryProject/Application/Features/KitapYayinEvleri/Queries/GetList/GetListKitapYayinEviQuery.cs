using MediatR;

namespace Application.Features.KitapYayinEvleri.Queries.GetList;

public class GetListKitapYayinEviQuery : IRequest<IReadOnlyList<GetListKitapYayinEviItemDto>>
{
    public class Handler : IRequestHandler<GetListKitapYayinEviQuery, IReadOnlyList<GetListKitapYayinEviItemDto>>
    {
        public Task<IReadOnlyList<GetListKitapYayinEviItemDto>> Handle(GetListKitapYayinEviQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult<IReadOnlyList<GetListKitapYayinEviItemDto>>(Array.Empty<GetListKitapYayinEviItemDto>());
        }
    }
}


