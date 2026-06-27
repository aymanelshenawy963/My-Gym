namespace GymManagement.Core.Contracts.Authentication;


public record RefreshTokenRequest(
    string Token,
    string RefreshToken
    );

