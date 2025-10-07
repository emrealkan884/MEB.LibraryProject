using FluentValidation;

namespace Application.Features.KopyalarKonumlar.Commands.Update;

public class UpdateKopyaKonumCommandValidator : AbstractValidator<UpdateKopyaKonumCommand>
{
    public UpdateKopyaKonumCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.KopyaId).NotEmpty();
        RuleFor(c => c.KonumId).NotEmpty();
        RuleFor(c => c.KutuphaneId).NotEmpty();
        RuleFor(c => c.Adet).NotEmpty();
    }
}