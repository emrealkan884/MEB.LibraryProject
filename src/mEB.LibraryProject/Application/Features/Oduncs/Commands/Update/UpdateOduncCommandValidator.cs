using FluentValidation;

namespace Application.Features.Oduncs.Commands.Update;

public class UpdateOduncCommandValidator : AbstractValidator<UpdateOduncCommand>
{
    public UpdateOduncCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.KopyaId).NotEmpty();
        RuleFor(c => c.KullaniciId).NotEmpty();
        RuleFor(c => c.KutuphaneId).NotEmpty();
        RuleFor(c => c.OduncAlmaTarihi).NotEmpty();
        RuleFor(c => c.SonTeslimTarihi).NotEmpty();
        RuleFor(c => c.Durum).NotEmpty();
    }
}