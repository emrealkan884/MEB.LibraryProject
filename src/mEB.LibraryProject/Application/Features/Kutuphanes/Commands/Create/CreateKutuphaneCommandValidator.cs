using FluentValidation;

namespace Application.Features.Kutuphanes.Commands.Create;

public class CreateKutuphaneCommandValidator : AbstractValidator<CreateKutuphaneCommand>
{
    public CreateKutuphaneCommandValidator()
    {
        RuleFor(c => c.Adi).NotEmpty();
        RuleFor(c => c.Adres).NotEmpty();
        RuleFor(c => c.KurumTuru).NotEmpty();
    }
}