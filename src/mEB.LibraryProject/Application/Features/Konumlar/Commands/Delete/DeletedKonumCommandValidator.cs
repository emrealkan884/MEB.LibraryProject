using FluentValidation;

namespace Application.Features.Konumlar.Commands.Delete;

public class DeleteKonumCommandValidator : AbstractValidator<DeleteKonumCommand>
{
    public DeleteKonumCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}