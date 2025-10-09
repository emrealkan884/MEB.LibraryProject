using MediatR;

namespace Application.Features.DijitalIcerikler.Commands.Create;

public class CreateDijitalIcerikCommand : IRequest<CreatedDijitalIcerikResponse>
{
    public Guid EserId { get; set; }
    public required string Tur { get; set; }
    public required string Url { get; set; }

    public class Handler : IRequestHandler<CreateDijitalIcerikCommand, CreatedDijitalIcerikResponse>
    {
        public Task<CreatedDijitalIcerikResponse> Handle(CreateDijitalIcerikCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new CreatedDijitalIcerikResponse { Id = Guid.Empty });
        }
    }
}


