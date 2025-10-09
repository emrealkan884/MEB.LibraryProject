using MediatR;

namespace Application.Features.DijitalIcerikler.Commands.Delete;

public class DeleteDijitalIcerikCommand : IRequest<DeletedDijitalIcerikResponse>
{
    public Guid Id { get; set; }

    public class Handler : IRequestHandler<DeleteDijitalIcerikCommand, DeletedDijitalIcerikResponse>
    {
        public Task<DeletedDijitalIcerikResponse> Handle(DeleteDijitalIcerikCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new DeletedDijitalIcerikResponse { Id = request.Id });
        }
    }
}


