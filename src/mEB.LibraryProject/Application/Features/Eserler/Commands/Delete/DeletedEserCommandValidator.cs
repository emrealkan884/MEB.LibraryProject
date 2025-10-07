using FluentValidation;

namespace Application.Features.Eserler.Commands.Delete;

public class DeleteEserCommandValidator : AbstractValidator<DeleteEserCommand>
{
    public DeleteEserCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}