using FluentValidation;

namespace Application.Features.KitapYayinEvleri.Commands.Create;

public class CreateKitapYayinEviCommandValidator : AbstractValidator<CreateKitapYayinEviCommand>
{
    public CreateKitapYayinEviCommandValidator()
    {
        RuleFor(x => x.KitapId).NotEmpty();
        RuleFor(x => x.YayinEviId).NotEmpty();
    }
}


