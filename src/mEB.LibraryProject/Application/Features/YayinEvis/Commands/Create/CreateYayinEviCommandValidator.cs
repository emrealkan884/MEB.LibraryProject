using FluentValidation;

namespace Application.Features.YayinEvis.Commands.Create;

public class CreateYayinEviCommandValidator : AbstractValidator<CreateYayinEviCommand>
{
    public CreateYayinEviCommandValidator()
    {
        RuleFor(c => c.Adi).NotEmpty();
    }
}