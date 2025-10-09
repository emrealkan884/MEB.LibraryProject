using MediatR;

namespace Application.Features.DijitalIcerikler.Queries.GetById;

public class GetByIdDijitalIcerikQuery : IRequest<GetByIdDijitalIcerikResponse>
{
    public Guid Id { get; set; }

    public class Handler : IRequestHandler<GetByIdDijitalIcerikQuery, GetByIdDijitalIcerikResponse>
    {
        public Task<GetByIdDijitalIcerikResponse> Handle(GetByIdDijitalIcerikQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetByIdDijitalIcerikResponse { Id = request.Id });
        }
    }
}


