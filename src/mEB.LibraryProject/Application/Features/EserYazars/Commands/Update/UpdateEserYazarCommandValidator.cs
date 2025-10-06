using FluentValidation;

namespace Application.Features.EserYazars.Commands.Update;

public class UpdateEserYazarCommandValidator : AbstractValidator<UpdateEserYazarCommand>
{
    public UpdateEserYazarCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.EserId).NotEmpty();
        RuleFor(c => c.YazarId).NotEmpty();
    }
}