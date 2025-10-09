using MediatR;

namespace Application.Features.KitapYayinEvleri.Commands.Create;

public class CreateKitapYayinEviCommand : IRequest<CreatedKitapYayinEviResponse>
{
    public Guid KitapId { get; set; }
    public Guid YayinEviId { get; set; }

    public class Handler : IRequestHandler<CreateKitapYayinEviCommand, CreatedKitapYayinEviResponse>
    {
        public Task<CreatedKitapYayinEviResponse> Handle(CreateKitapYayinEviCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new CreatedKitapYayinEviResponse { Id = Guid.Empty });
        }
    }
}


