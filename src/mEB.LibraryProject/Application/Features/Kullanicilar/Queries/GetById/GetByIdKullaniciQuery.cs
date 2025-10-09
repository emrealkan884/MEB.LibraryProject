using MediatR;

namespace Application.Features.Kullanicilar.Queries.GetById;

public class GetByIdKullaniciQuery : IRequest<GetByIdKullaniciResponse>
{
    public Guid Id { get; set; }

    public class Handler : IRequestHandler<GetByIdKullaniciQuery, GetByIdKullaniciResponse>
    {
        public Task<GetByIdKullaniciResponse> Handle(GetByIdKullaniciQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetByIdKullaniciResponse { Id = request.Id });
        }
    }
}


