using AzureFunction.Model;
using FluentValidation;

namespace AzureFunction.Validation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email is invalid.");

            RuleFor(x => x.Password)
               .NotEmpty().WithMessage("Password is required.");
        }
    }
}
