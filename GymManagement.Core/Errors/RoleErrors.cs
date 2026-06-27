using GymManagement.Core.Abstractions;
using Microsoft.AspNetCore.Http;

namespace GymManagement.Core.Errors;

public record RoleErros
{
    public static readonly Error RoleNotFound =
        new("Role.RoleNotFound", "Role is not fiond", StatusCodes.Status404NotFound);

    public static readonly Error InvalidPermissions =
       new("Role.InvalidPermissions", "Invalid permissions", StatusCodes.Status400BadRequest);

    //  public static readonly Error InvalidRefreshToken =
    //     new("User.InvalidRefreshToken", "Invalid refresh token", StatusCodes.Status401Unauthorized );

    public static readonly Error DuplicatedRole =
       new("Role.DuplicatedRole", "Anthor role with the same name already exists", StatusCodes.Status409Conflict);

    //  public static readonly Error EmailNotConfirmed =
    // new("User.EmailNotConfirmed", "Email is not confirmed", StatusCodes.Status401Unauthorized);

    //  public static readonly Error InvalideCode =
    //new("User.InvalideCode", "Ivalide code", StatusCodes.Status401Unauthorized);

    //  public static readonly Error DuplicatedConfirmation =
    //new("User.DuplicatedConfirmation", "Email is alredy confirmed", StatusCodes.Status400BadRequest);
}
