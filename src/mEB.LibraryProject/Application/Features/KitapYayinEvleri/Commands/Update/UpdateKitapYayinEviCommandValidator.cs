using FluentValidation;

namespace Application.Features.KitapYayinEvleri.Commands.Update;

public class UpdateKitapYayinEviCommandValidator : AbstractValidator<UpdateKitapYayinEviCommand>
{
    public UpdateKitapYayinEviCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}


