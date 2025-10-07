using FluentValidation;

namespace Application.Features.Konumlar.Commands.Create;

public class CreateKonumCommandValidator : AbstractValidator<CreateKonumCommand>
{
    public CreateKonumCommandValidator()
    {
        RuleFor(c => c.KutuphaneId).NotEmpty();
        RuleFor(c => c.KonumTip).NotEmpty();
        RuleFor(c => c.Ad).NotEmpty();
    }
}