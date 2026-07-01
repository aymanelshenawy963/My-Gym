namespace GymManagement.Core.Contracts.Users;

public record ChangePasswordRequest(
    string CurrntPassword,
    string NewPassword
    );
