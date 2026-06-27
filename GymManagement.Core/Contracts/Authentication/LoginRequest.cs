namespace GymManagement.Core.Contracts.Authentication;


public record LoginRequest(
    string Email,
    string Password
    );
