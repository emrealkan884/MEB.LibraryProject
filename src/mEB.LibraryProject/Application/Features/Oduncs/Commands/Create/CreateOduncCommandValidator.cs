using FluentValidation;

namespace Application.Features.Oduncs.Commands.Create;

public class CreateOduncCommandValidator : AbstractValidator<CreateOduncCommand>
{
    public CreateOduncCommandValidator()
    {
        RuleFor(c => c.KopyaId).NotEmpty();
        RuleFor(c => c.KullaniciId).NotEmpty();
        RuleFor(c => c.KutuphaneId).NotEmpty();
        RuleFor(c => c.SonTeslimTarihi).NotEmpty();
        RuleFor(c => c.IleriTarihIcinMi).NotEmpty();
    }
}