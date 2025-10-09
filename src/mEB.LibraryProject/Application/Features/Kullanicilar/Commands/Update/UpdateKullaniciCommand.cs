using MediatR;

namespace Application.Features.Kullanicilar.Commands.Update;

public class UpdateKullaniciCommand : IRequest<UpdatedKullaniciResponse>
{
    public Guid Id { get; set; }
    public string? Adi { get; set; }
    public string? Soyadi { get; set; }

    public class Handler : IRequestHandler<UpdateKullaniciCommand, UpdatedKullaniciResponse>
    {
        public Task<UpdatedKullaniciResponse> Handle(UpdateKullaniciCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new UpdatedKullaniciResponse { Id = request.Id });
        }
    }
}


