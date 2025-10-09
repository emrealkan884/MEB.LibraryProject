using FluentValidation;

namespace Application.Features.KitapBaskilar.Commands.Create;

public class CreateKitapBaskiCommandValidator : AbstractValidator<CreateKitapBaskiCommand>
{
    public CreateKitapBaskiCommandValidator()
    {
        RuleFor(x => x.KitapId).NotEmpty();
        RuleFor(x => x.YayinEviId).NotEmpty();
        RuleFor(x => x.Isbn).NotEmpty().MinimumLength(10).MaximumLength(20);
    }
}


