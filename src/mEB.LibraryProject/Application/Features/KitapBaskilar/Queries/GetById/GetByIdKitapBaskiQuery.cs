using MediatR;

namespace Application.Features.KitapBaskilar.Queries.GetById;

public class GetByIdKitapBaskiQuery : IRequest<GetByIdKitapBaskiResponse>
{
    public Guid Id { get; set; }

    public class Handler : IRequestHandler<GetByIdKitapBaskiQuery, GetByIdKitapBaskiResponse>
    {
        public Task<GetByIdKitapBaskiResponse> Handle(GetByIdKitapBaskiQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetByIdKitapBaskiResponse { Id = request.Id });
        }
    }
}

