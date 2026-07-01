using FluentValidation;
using GymManagement.Core.Abstractions.Const;
using GymManagement.Core.Contracts.Users;

namespace GymManagement.Core.Contracts.Users;


public class ChangePasswordRequestValidator : AbstractValidator<ChangePasswordRequest>
{
    public ChangePasswordRequestValidator()
    {

        RuleFor(x => x.CurrntPassword).NotEmpty();


        RuleFor(x => x.NewPassword).NotEmpty()
            .Matches(RegexPatterns.Password)
            .WithMessage("Password should be at least 8 digits and should contains Lowercase,NonAlphanumric and Uppercase")
            .NotEqual(x => x.CurrntPassword)
            .WithMessage("New Password cannot be same as the current password");
    }

}


