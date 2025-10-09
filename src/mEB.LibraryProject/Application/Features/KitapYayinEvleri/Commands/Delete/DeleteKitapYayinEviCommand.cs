using MediatR;

namespace Application.Features.KitapYayinEvleri.Commands.Delete;

public class DeleteKitapYayinEviCommand : IRequest<DeletedKitapYayinEviResponse>
{
    public Guid Id { get; set; }

    public class Handler : IRequestHandler<DeleteKitapYayinEviCommand, DeletedKitapYayinEviResponse>
    {
        public Task<DeletedKitapYayinEviResponse> Handle(DeleteKitapYayinEviCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new DeletedKitapYayinEviResponse { Id = request.Id });
        }
    }
}


