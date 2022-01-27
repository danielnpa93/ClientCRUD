using FluentValidation;
using UserLogin.Domain.Entities;

namespace UserLogin.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty().WithMessage("Entity cannot be empty")
                .NotNull().WithMessage("Entity cannot be null");

            RuleFor(x => x.FirstName)
                .NotNull().WithMessage("Cannot be null")
                .NotEmpty().WithMessage("Cannot be empty")
                .MinimumLength(3).WithMessage("At least 3 characters")
                .MaximumLength(50).WithMessage("Maximum of 50 characters");


            RuleFor(x => x.LastName)
                .NotNull().WithMessage("Cannot be null")
                .NotEmpty().WithMessage("Cannot be empty")
                .MinimumLength(1).WithMessage("At least 1 characters")
                .MaximumLength(80).WithMessage("Maximum of 80 characters");

            RuleFor(x => x.Email)
                .NotNull().WithMessage("Cannot be null")
                .NotEmpty().WithMessage("Cannot be empty")
                .MaximumLength(50).WithMessage("Maximum of 50 characters")
                .EmailAddress().WithMessage("A valid email is required");

            RuleFor(x => x.Password)
                 .NotNull().WithMessage("Cannot be null")
                .NotEmpty().WithMessage("Cannot be empty")
                .MinimumLength(3).WithMessage("At least 6 characters")
                .MaximumLength(50).WithMessage("Maximum of 50 characters");

        }

    }
}
