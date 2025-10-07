using FluentValidation;

namespace Application.Features.EserlerYazarlar.Commands.Delete;

public class DeleteEserYazarCommandValidator : AbstractValidator<DeleteEserYazarCommand>
{
    public DeleteEserYazarCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}