using MediatR;

namespace Application.Features.Kullanicilar.Queries.GetList;

public class GetListKullaniciQuery : IRequest<IReadOnlyList<GetListKullaniciItemDto>>
{
    public class Handler : IRequestHandler<GetListKullaniciQuery, IReadOnlyList<GetListKullaniciItemDto>>
    {
        public Task<IReadOnlyList<GetListKullaniciItemDto>> Handle(GetListKullaniciQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult<IReadOnlyList<GetListKullaniciItemDto>>(Array.Empty<GetListKullaniciItemDto>());
        }
    }
}


