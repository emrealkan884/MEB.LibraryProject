using FluentValidation;

namespace Application.Features.Oduncs.Commands.TeslimEt;

public class TeslimEtOduncCommandValidator:AbstractValidator<TeslimEtOduncCommand>
{
    public TeslimEtOduncCommandValidator()
    {
        RuleFor(c => c.OduncId).NotEmpty();
    }
}