using FluentValidation;

namespace Application.Features.EserYazars.Commands.Create;

public class CreateEserYazarCommandValidator : AbstractValidator<CreateEserYazarCommand>
{
    public CreateEserYazarCommandValidator()
    {
        RuleFor(c => c.EserId).NotEmpty();
        RuleFor(c => c.YazarId).NotEmpty();
    }
}