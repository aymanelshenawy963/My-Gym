using System.Security.Claims;

namespace GymManagement.API.Extentsions;

public static class UserExtentsions
{
    public static string? GetUserId(this ClaimsPrincipal user) =>
     user.FindFirstValue(ClaimTypes.NameIdentifier);


}

