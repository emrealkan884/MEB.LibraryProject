using FluentValidation;

namespace Application.Features.DijitalIcerikler.Commands.Update;

public class UpdateDijitalIcerikCommandValidator : AbstractValidator<UpdateDijitalIcerikCommand>
{
    public UpdateDijitalIcerikCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Url).MaximumLength(2048).When(x => x.Url != null);
        RuleFor(x => x.Tur).MaximumLength(50).When(x => x.Tur != null);
    }
}


