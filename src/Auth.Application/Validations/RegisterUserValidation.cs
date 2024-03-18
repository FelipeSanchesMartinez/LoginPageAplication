using Auth.Application.ViewModels;
using FluentValidation;

namespace Auth.Application.Validations
{
    public class RegisterUserValidation : AbstractValidator<RegisterUserViewModel>
    {
        public RegisterUserValidation()
        {
            RuleFor(x => x.Email)
                .MaximumLength(100)
                .NotEmpty().NotNull().EmailAddress();
           
            RuleFor(x => x.Password)
                .MaximumLength(100)
                .NotEmpty()
                .NotNull()
                .Equal(x=>x.ConfirmPassword);
        }
    }
}
