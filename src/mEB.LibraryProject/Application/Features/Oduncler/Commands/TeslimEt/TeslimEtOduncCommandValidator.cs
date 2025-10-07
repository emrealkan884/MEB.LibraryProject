using FluentValidation;

namespace Application.Features.Oduncler.Commands.TeslimEt;

public class TeslimEtOduncCommandValidator:AbstractValidator<TeslimEtOduncCommand>
{
    public TeslimEtOduncCommandValidator()
    {
        RuleFor(c => c.OduncId).NotEmpty();
    }
}