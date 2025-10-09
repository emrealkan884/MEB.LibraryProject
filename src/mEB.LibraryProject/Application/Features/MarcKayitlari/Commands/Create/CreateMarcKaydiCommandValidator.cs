using FluentValidation;

namespace Application.Features.MarcKayitlari.Commands.Create;

public class CreateMarcKaydiCommandValidator : AbstractValidator<CreateMarcKaydiCommand>
{
    public CreateMarcKaydiCommandValidator()
    {
        RuleFor(x => x.Veri).NotEmpty();
    }
}


