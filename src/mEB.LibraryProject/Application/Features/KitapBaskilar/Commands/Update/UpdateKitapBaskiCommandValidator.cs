using FluentValidation;

namespace Application.Features.KitapBaskilar.Commands.Update;

public class UpdateKitapBaskiCommandValidator : AbstractValidator<UpdateKitapBaskiCommand>
{
    public UpdateKitapBaskiCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Isbn).MaximumLength(20).When(x => x.Isbn != null);
    }
}


