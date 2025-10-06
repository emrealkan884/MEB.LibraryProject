using FluentValidation;

namespace Application.Features.YayinEvis.Commands.Update;

public class UpdateYayinEviCommandValidator : AbstractValidator<UpdateYayinEviCommand>
{
    public UpdateYayinEviCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Adi).NotEmpty();
    }
}