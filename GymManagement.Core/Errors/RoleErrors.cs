using GymManagement.Core.Abstractions;
using Microsoft.AspNetCore.Http;

namespace GymManagement.Core.Errors;

public record RoleErros
{
    public static readonly Error RoleNotFound =
        new("Role.RoleNotFound", "Role is not fiond", StatusCodes.Status404NotFound);


    public static readonly Error DuplicatedRole =
       new("Role.DuplicatedRole", "Anthor role with the same name already exists", StatusCodes.Status409Conflict);

}
