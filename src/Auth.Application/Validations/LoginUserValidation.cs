using Auth.Application.ViewModels;
using FluentValidation;

namespace Auth.Application.Validations
{
    public class LoginUserValidation : AbstractValidator<LoginUserViewModel>
    {
        public LoginUserValidation()
        {
            RuleFor(x => x.Email)
                .MaximumLength(100)
                .NotEmpty()
                .NotNull()
                .EmailAddress();


            RuleFor(x => x.Password)
            .MaximumLength(100)
            .NotEmpty()
            .NotNull();
        }
    }
}
