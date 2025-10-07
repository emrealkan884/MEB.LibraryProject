
using FluentValidation;


public class UpdateKitapCommandValidator : AbstractValidator<UpdateKitapCommand>
{
    public UpdateKitapCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Adi).NotEmpty();
        RuleFor(c => c.DilKodu).NotEmpty();
        RuleFor(c => c.Aciklama).NotEmpty();
    }
}