using FluentValidation;

namespace Application.Features.Konums.Commands.Update;

public class UpdateKonumCommandValidator : AbstractValidator<UpdateKonumCommand>
{
    public UpdateKonumCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.KutuphaneId).NotEmpty();
        RuleFor(c => c.KonumTip).NotEmpty();
        RuleFor(c => c.Ad).NotEmpty();
    }
}