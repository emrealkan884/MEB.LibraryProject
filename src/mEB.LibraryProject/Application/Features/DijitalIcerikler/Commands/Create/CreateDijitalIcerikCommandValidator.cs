using FluentValidation;

namespace Application.Features.DijitalIcerikler.Commands.Create;

public class CreateDijitalIcerikCommandValidator : AbstractValidator<CreateDijitalIcerikCommand>
{
    public CreateDijitalIcerikCommandValidator()
    {
        RuleFor(x => x.EserId).NotEmpty();
        RuleFor(x => x.Tur).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Url).NotEmpty().MaximumLength(2048);
    }
}


