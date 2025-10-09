using MediatR;

namespace Application.Features.KitapBaskilar.Commands.Update;

public class UpdateKitapBaskiCommand : IRequest<UpdatedKitapBaskiResponse>
{
    public Guid Id { get; set; }
    public string? Isbn { get; set; }

    public class Handler : IRequestHandler<UpdateKitapBaskiCommand, UpdatedKitapBaskiResponse>
    {
        public Task<UpdatedKitapBaskiResponse> Handle(UpdateKitapBaskiCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new UpdatedKitapBaskiResponse { Id = request.Id });
        }
    }
}

