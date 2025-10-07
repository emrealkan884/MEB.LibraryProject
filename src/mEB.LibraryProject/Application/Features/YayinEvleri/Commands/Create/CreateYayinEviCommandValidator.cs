using FluentValidation;

namespace Application.Features.YayinEvleri.Commands.Create;

public class CreateYayinEviCommandValidator : AbstractValidator<CreateYayinEviCommand>
{
    public CreateYayinEviCommandValidator()
    {
        RuleFor(c => c.Adi).NotEmpty();
    }
}