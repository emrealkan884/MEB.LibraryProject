using MediatR;

namespace Application.Features.Kullanicilar.Commands.Delete;

public class DeleteKullaniciCommand : IRequest<DeletedKullaniciResponse>
{
    public Guid Id { get; set; }

    public class Handler : IRequestHandler<DeleteKullaniciCommand, DeletedKullaniciResponse>
    {
        public Task<DeletedKullaniciResponse> Handle(DeleteKullaniciCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new DeletedKullaniciResponse { Id = request.Id });
        }
    }
}


