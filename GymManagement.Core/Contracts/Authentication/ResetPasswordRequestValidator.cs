using FluentValidation;
using GymManagement.Core.Abstractions.Const;
using GymManagement.Core.Contracts.Authentication;

namespace GymManagement.Core.Contracts;

public class ResetPasswordRequestValidator : AbstractValidator<ResetPasswordRequest>
{
    public ResetPasswordRequestValidator()
    {

        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Code).NotEmpty();

        RuleFor(x => x.NewPassword).NotEmpty()
            .Matches(RegexPatterns.Password)
            .WithMessage("Password should be at least 8 digits and should contains Lowercase,NonAlphanumric and Uppercase");

    }

}

