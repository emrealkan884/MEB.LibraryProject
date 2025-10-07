using FluentValidation;

namespace Application.Features.Kutuphaneler.Commands.Update;

public class UpdateKutuphaneCommandValidator : AbstractValidator<UpdateKutuphaneCommand>
{
    public UpdateKutuphaneCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Adi).NotEmpty();
        RuleFor(c => c.Adres).NotEmpty();
        RuleFor(c => c.KurumTuru).NotEmpty();
    }
}