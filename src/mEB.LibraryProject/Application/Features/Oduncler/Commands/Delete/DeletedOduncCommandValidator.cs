using FluentValidation;

namespace Application.Features.Oduncler.Commands.Delete;

public class DeleteOduncCommandValidator : AbstractValidator<DeleteOduncCommand>
{
    public DeleteOduncCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}