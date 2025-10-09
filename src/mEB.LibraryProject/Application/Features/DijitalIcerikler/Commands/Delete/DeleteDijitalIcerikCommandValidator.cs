using FluentValidation;

namespace Application.Features.DijitalIcerikler.Commands.Delete;

public class DeleteDijitalIcerikCommandValidator : AbstractValidator<DeleteDijitalIcerikCommand>
{
    public DeleteDijitalIcerikCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}


