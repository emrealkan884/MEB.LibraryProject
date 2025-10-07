using FluentValidation;

namespace Application.Features.KopyalarKonumlar.Commands.Create;

public class CreateKopyaKonumCommandValidator : AbstractValidator<CreateKopyaKonumCommand>
{
    public CreateKopyaKonumCommandValidator()
    {
        RuleFor(c => c.KopyaId).NotEmpty();
        RuleFor(c => c.KonumId).NotEmpty();
        RuleFor(c => c.KutuphaneId).NotEmpty();
        RuleFor(c => c.Adet).NotEmpty();
    }
}