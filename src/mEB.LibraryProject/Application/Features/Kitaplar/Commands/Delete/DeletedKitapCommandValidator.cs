
using FluentValidation;


public class DeleteKitapCommandValidator : AbstractValidator<DeleteKitapCommand>
{
    public DeleteKitapCommandValidator()
    {
        RuleFor(k=>k.Id).NotEmpty();
    }
}