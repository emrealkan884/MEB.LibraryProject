using FluentValidation;

namespace Application.Features.Kopyas.Commands.Update;

public class UpdateKopyaCommandValidator : AbstractValidator<UpdateKopyaCommand>
{
    public UpdateKopyaCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.KitapId).NotEmpty();
        RuleFor(c => c.KutuphaneId).NotEmpty();
        RuleFor(c => c.Barkod).NotEmpty();
    }
}