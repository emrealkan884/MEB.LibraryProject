using MediatR;

namespace Application.Features.Kullanicilar.Commands.Create;

public class CreateKullaniciCommand : IRequest<CreatedKullaniciResponse>
{
    public required string Adi { get; set; }
    public required string Soyadi { get; set; }

    public class Handler : IRequestHandler<CreateKullaniciCommand, CreatedKullaniciResponse>
    {
        public Task<CreatedKullaniciResponse> Handle(CreateKullaniciCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new CreatedKullaniciResponse { Id = Guid.Empty });
        }
    }
}


