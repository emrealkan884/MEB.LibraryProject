using FluentValidation;

namespace Application.Features.EserYazars.Commands.Delete;

public class DeleteEserYazarCommandValidator : AbstractValidator<DeleteEserYazarCommand>
{
    public DeleteEserYazarCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}