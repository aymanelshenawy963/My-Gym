namespace GymManagement.Core.Contracts.Users;


public record UserResponse
    (
    string Id,
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    bool IsDisabled,
    IEnumerable<string> Roles
    );

