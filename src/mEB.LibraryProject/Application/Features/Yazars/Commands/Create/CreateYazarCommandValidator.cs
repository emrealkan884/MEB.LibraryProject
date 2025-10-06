using FluentValidation;

namespace Application.Features.Yazars.Commands.Create;

public class CreateYazarCommandValidator : AbstractValidator<CreateYazarCommand>
{
    public CreateYazarCommandValidator()
    {
        RuleFor(c => c.Adi).NotEmpty();
        RuleFor(c => c.Soyadi).NotEmpty();
    }
}