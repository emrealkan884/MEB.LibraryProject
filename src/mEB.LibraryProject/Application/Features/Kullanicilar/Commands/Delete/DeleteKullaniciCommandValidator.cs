using FluentValidation;

namespace Application.Features.Kullanicilar.Commands.Delete;

public class DeleteKullaniciCommandValidator : AbstractValidator<DeleteKullaniciCommand>
{
    public DeleteKullaniciCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}


