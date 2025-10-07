using FluentValidation;

namespace Application.Features.Eserler.Commands.Create;

public class CreateEserCommandValidator : AbstractValidator<CreateEserCommand>
{
    public CreateEserCommandValidator()
    {
        RuleFor(c => c.Adi).NotEmpty();
        RuleFor(c => c.DilKodu).NotEmpty();
        RuleFor(c => c.Aciklama).NotEmpty();
    }
}