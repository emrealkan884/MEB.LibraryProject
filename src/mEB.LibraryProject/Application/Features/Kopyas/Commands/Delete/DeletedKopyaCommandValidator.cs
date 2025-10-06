using FluentValidation;

namespace Application.Features.Kopyas.Commands.Delete;

public class DeleteKopyaCommandValidator : AbstractValidator<DeleteKopyaCommand>
{
    public DeleteKopyaCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}