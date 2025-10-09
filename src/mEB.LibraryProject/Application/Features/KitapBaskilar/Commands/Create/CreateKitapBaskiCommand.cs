using MediatR;

namespace Application.Features.KitapBaskilar.Commands.Create;

public class CreateKitapBaskiCommand : IRequest<CreatedKitapBaskiResponse>
{
    public Guid KitapId { get; set; }
    public Guid YayinEviId { get; set; }
    public required string Isbn { get; set; }

    public class Handler : IRequestHandler<CreateKitapBaskiCommand, CreatedKitapBaskiResponse>
    {
        public Task<CreatedKitapBaskiResponse> Handle(CreateKitapBaskiCommand request, CancellationToken cancellationToken)
        {
            // Skeleton: implement later
            return Task.FromResult(new CreatedKitapBaskiResponse { Id = Guid.Empty });
        }
    }
}

