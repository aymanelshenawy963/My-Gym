namespace GymManagement.Core.Contracts.Authentication;


public record AuthResponse(
    string Id,
    string? Email,
    string FirstName,
    string LastName,
    string Token,
    int ExiresIn,
    string RefreshToken,
    DateTime RefreshTokenExpiraTion
    );

