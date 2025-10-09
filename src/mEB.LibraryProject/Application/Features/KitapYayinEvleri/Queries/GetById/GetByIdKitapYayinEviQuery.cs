using MediatR;

namespace Application.Features.KitapYayinEvleri.Queries.GetById;

public class GetByIdKitapYayinEviQuery : IRequest<GetByIdKitapYayinEviResponse>
{
    public Guid Id { get; set; }

    public class Handler : IRequestHandler<GetByIdKitapYayinEviQuery, GetByIdKitapYayinEviResponse>
    {
        public Task<GetByIdKitapYayinEviResponse> Handle(GetByIdKitapYayinEviQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetByIdKitapYayinEviResponse { Id = request.Id });
        }
    }
}


