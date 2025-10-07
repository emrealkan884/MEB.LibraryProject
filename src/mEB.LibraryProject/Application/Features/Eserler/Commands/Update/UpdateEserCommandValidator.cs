using FluentValidation;

namespace Application.Features.Eserler.Commands.Update;

public class UpdateEserCommandValidator : AbstractValidator<UpdateEserCommand>
{
    public UpdateEserCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Adi).NotEmpty();
        RuleFor(c => c.DilKodu).NotEmpty();
        RuleFor(c => c.Aciklama).NotEmpty();
    }
}