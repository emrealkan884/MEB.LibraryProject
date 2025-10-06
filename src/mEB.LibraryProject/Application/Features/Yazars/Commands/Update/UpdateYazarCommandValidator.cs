using FluentValidation;

namespace Application.Features.Yazars.Commands.Update;

public class UpdateYazarCommandValidator : AbstractValidator<UpdateYazarCommand>
{
    public UpdateYazarCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Adi).NotEmpty();
        RuleFor(c => c.Soyadi).NotEmpty();
    }
}