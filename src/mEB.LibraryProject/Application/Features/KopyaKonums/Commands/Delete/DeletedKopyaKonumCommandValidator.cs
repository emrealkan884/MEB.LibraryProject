using FluentValidation;

namespace Application.Features.KopyaKonums.Commands.Delete;

public class DeleteKopyaKonumCommandValidator : AbstractValidator<DeleteKopyaKonumCommand>
{
    public DeleteKopyaKonumCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}