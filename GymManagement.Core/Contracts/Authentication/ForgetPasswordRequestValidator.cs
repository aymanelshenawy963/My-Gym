using FluentValidation;

namespace GymManagement.Core.Contracts.Authentication;

public class ForgetPasswordRequestValidator : AbstractValidator<ForgetPasswordRequest>
{
    public ForgetPasswordRequestValidator()
    {

        RuleFor(x => x.Email).NotEmpty().EmailAddress();

    }

}

