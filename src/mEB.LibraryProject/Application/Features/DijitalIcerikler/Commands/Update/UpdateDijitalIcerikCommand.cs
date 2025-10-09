using MediatR;

namespace Application.Features.DijitalIcerikler.Commands.Update;

public class UpdateDijitalIcerikCommand : IRequest<UpdatedDijitalIcerikResponse>
{
    public Guid Id { get; set; }
    public string? Tur { get; set; }
    public string? Url { get; set; }

    public class Handler : IRequestHandler<UpdateDijitalIcerikCommand, UpdatedDijitalIcerikResponse>
    {
        public Task<UpdatedDijitalIcerikResponse> Handle(UpdateDijitalIcerikCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new UpdatedDijitalIcerikResponse { Id = request.Id });
        }
    }
}


