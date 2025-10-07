using FluentValidation;

namespace Application.Features.EserlerYazarlar.Commands.Create;

public class CreateEserYazarCommandValidator : AbstractValidator<CreateEserYazarCommand>
{
    public CreateEserYazarCommandValidator()
    {
        RuleFor(c => c.EserId).NotEmpty();
        RuleFor(c => c.YazarId).NotEmpty();
    }
}