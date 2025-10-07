using FluentValidation;

namespace Application.Features.KopyalarKonumlar.Commands.Delete;

public class DeleteKopyaKonumCommandValidator : AbstractValidator<DeleteKopyaKonumCommand>
{
    public DeleteKopyaKonumCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}