using FluentValidation;

namespace Application.Features.KitapYayinEvleri.Commands.Delete;

public class DeleteKitapYayinEviCommandValidator : AbstractValidator<DeleteKitapYayinEviCommand>
{
    public DeleteKitapYayinEviCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}


