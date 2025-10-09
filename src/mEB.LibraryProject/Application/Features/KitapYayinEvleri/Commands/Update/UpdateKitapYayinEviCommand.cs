using MediatR;

namespace Application.Features.KitapYayinEvleri.Commands.Update;

public class UpdateKitapYayinEviCommand : IRequest<UpdatedKitapYayinEviResponse>
{
    public Guid Id { get; set; }
    public Guid? YayinEviId { get; set; }

    public class Handler : IRequestHandler<UpdateKitapYayinEviCommand, UpdatedKitapYayinEviResponse>
    {
        public Task<UpdatedKitapYayinEviResponse> Handle(UpdateKitapYayinEviCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new UpdatedKitapYayinEviResponse { Id = request.Id });
        }
    }
}


