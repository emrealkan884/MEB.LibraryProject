using FluentValidation;

namespace Application.Features.Kullanicilar.Commands.Create;

public class CreateKullaniciCommandValidator : AbstractValidator<CreateKullaniciCommand>
{
    public CreateKullaniciCommandValidator()
    {
        RuleFor(x => x.Adi).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Soyadi).NotEmpty().MaximumLength(100);
    }
}


