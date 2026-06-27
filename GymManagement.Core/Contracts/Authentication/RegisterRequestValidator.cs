using FluentValidation;
using GymManagement.Core.Abstractions.Const;

namespace GymManagement.Core.Contracts.Authentication;


public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.UserName)
    .NotEmpty().WithMessage("Username is required")
    .Length(3, 20).WithMessage("Username must be between 3 and 20 characters");
        RuleFor(x => x.Password).NotEmpty()
            .Matches(RegexPatterns.Password)
            .WithMessage("Password Should be at least 8 digtits contains LowerCase,NonAlphanumric and UpperCase");
        RuleFor(x => x.FirstName).NotEmpty().Length(3, 100);
        RuleFor(x => x.LastName).NotEmpty().Length(3, 100);
    }
}

