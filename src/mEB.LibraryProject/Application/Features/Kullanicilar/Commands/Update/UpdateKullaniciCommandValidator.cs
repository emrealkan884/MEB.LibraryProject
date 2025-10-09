using FluentValidation;

namespace Application.Features.Kullanicilar.Commands.Update;

public class UpdateKullaniciCommandValidator : AbstractValidator<UpdateKullaniciCommand>
{
    public UpdateKullaniciCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Adi).MaximumLength(100).When(x => x.Adi != null);
        RuleFor(x => x.Soyadi).MaximumLength(100).When(x => x.Soyadi != null);
    }
}


