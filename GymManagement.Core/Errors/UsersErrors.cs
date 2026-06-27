using GymManagement.Core.Abstractions;
using Microsoft.AspNetCore.Http;

namespace GymManagement.Core.Errors;

public record UsersErrors
{
    public static readonly Error InvalidCredentials =
        new("User.InvalidCredentional", "Invalid email/password", StatusCodes.Status401Unauthorized);

    public static readonly Error LockedUser =
        new("User.LockedUser", "LockedUser user, please contact Your adminstrator", StatusCodes.Status401Unauthorized);

    public static readonly Error DisabeldUser =
        new("User.DisabeldUser", "Disabeld user, please contact Your adminstrator", StatusCodes.Status401Unauthorized);

    public static readonly Error InvalidJwtToken =
       new("User.InvalidJwtToken", "Invalid Jwt Token", StatusCodes.Status401Unauthorized);

    public static readonly Error InvalidRefreshToken =
       new("User.InvalidRefreshToken", "Invalid refresh token", StatusCodes.Status401Unauthorized);

    public static readonly Error DuplicatedEmail =
       new("User.DuplicatedEmail", "Anthor user with the same email is already exists", StatusCodes.Status409Conflict);

    public static readonly Error DuplicatedUserName =
       new("User.DuplicatedUserName", "Anthor user with the same userName is already exists", StatusCodes.Status409Conflict);

    public static readonly Error EmailNotConfirmed =
   new("User.EmailNotConfirmed", "Email is not confirmed", StatusCodes.Status401Unauthorized);

    public static readonly Error InvalideCode =
  new("User.InvalideCode", "Ivalide code", StatusCodes.Status401Unauthorized);

    public static readonly Error DuplicatedConfirmation =
  new("User.DuplicatedConfirmation", "Email is alredy confirmed", StatusCodes.Status400BadRequest);

    public static readonly Error UserNotFound =
        new("User.UserNotFound", "User not found", StatusCodes.Status404NotFound);

    public static readonly Error InvalidRoles =
        new("User.InvalidRoles", "Invalid roles", StatusCodes.Status400BadRequest);

}
