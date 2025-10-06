using FluentValidation;

namespace Application.Features.Oduncs.Commands.Delete;

public class DeleteOduncCommandValidator : AbstractValidator<DeleteOduncCommand>
{
    public DeleteOduncCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}