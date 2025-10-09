using MediatR;

namespace Application.Features.DijitalIcerikler.Queries.GetList;

public class GetListDijitalIcerikQuery : IRequest<IReadOnlyList<GetListDijitalIcerikItemDto>>
{
    public class Handler : IRequestHandler<GetListDijitalIcerikQuery, IReadOnlyList<GetListDijitalIcerikItemDto>>
    {
        public Task<IReadOnlyList<GetListDijitalIcerikItemDto>> Handle(GetListDijitalIcerikQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult<IReadOnlyList<GetListDijitalIcerikItemDto>>(Array.Empty<GetListDijitalIcerikItemDto>());
        }
    }
}


