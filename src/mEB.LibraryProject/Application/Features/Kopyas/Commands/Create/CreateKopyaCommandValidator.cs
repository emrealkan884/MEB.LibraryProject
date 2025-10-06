using FluentValidation;

namespace Application.Features.Kopyas.Commands.Create;

public class CreateKopyaCommandValidator : AbstractValidator<CreateKopyaCommand>
{
    public CreateKopyaCommandValidator()
    {
        RuleFor(c => c.KitapId).NotEmpty();
        RuleFor(c => c.KutuphaneId).NotEmpty();
        RuleFor(c => c.Barkod).NotEmpty();
    }
}