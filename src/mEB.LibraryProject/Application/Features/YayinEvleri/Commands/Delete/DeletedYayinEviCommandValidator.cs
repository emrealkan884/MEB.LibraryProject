using FluentValidation;

namespace Application.Features.YayinEvleri.Commands.Delete;

public class DeleteYayinEviCommandValidator : AbstractValidator<DeleteYayinEviCommand>
{
    public DeleteYayinEviCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}