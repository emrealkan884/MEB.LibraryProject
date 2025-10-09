using MediatR;

namespace Application.Features.KitapBaskilar.Commands.Delete;

public class DeleteKitapBaskiCommand : IRequest<DeletedKitapBaskiResponse>
{
    public Guid Id { get; set; }

    public class Handler : IRequestHandler<DeleteKitapBaskiCommand, DeletedKitapBaskiResponse>
    {
        public Task<DeletedKitapBaskiResponse> Handle(DeleteKitapBaskiCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new DeletedKitapBaskiResponse { Id = request.Id });
        }
    }
}

