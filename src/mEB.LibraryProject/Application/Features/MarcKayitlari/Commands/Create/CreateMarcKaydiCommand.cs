using MediatR;

namespace Application.Features.MarcKayitlari.Commands.Create;

public class CreateMarcKaydiCommand : IRequest<CreatedMarcKaydiResponse>
{
    public required string Veri { get; set; }

    public class Handler : IRequestHandler<CreateMarcKaydiCommand, CreatedMarcKaydiResponse>
    {
        public Task<CreatedMarcKaydiResponse> Handle(CreateMarcKaydiCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new CreatedMarcKaydiResponse { Id = Guid.Empty });
        }
    }
}


