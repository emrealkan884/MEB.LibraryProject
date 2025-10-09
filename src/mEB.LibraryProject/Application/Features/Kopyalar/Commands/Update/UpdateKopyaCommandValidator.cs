using FluentValidation;

namespace Application.Features.Kopyalar.Commands.Update;

public class UpdateKopyaCommandValidator : AbstractValidator<UpdateKopyaCommand>
{
    public UpdateKopyaCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.KitapBaskiId).NotEmpty();
        RuleFor(c => c.KutuphaneId).NotEmpty();
        RuleFor(c => c.Barkod).NotEmpty();
    }
}