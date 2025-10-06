using FluentValidation;

namespace Application.Features.YayinEvis.Commands.Delete;

public class DeleteYayinEviCommandValidator : AbstractValidator<DeleteYayinEviCommand>
{
    public DeleteYayinEviCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}