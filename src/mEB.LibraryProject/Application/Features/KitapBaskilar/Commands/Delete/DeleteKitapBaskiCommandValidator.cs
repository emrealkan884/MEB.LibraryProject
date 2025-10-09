using FluentValidation;

namespace Application.Features.KitapBaskilar.Commands.Delete;

public class DeleteKitapBaskiCommandValidator : AbstractValidator<DeleteKitapBaskiCommand>
{
    public DeleteKitapBaskiCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}


