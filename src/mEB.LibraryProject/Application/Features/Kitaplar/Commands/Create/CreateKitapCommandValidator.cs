using FluentValidation;


public class CreateKitapCommandValidator : AbstractValidator<CreateKitapCommand>
{
    public CreateKitapCommandValidator()
    {
        RuleFor(c => c.Adi).NotEmpty();
        RuleFor(c => c.DilKodu).NotEmpty();
        RuleFor(c => c.ISBN).NotEmpty();
        RuleFor(c => c.YayinEviId).NotEmpty();
        RuleFor(c => c.DeweyKodu).NotEmpty();
        RuleFor(c => c.MarcVerisi).NotEmpty();
    }
}