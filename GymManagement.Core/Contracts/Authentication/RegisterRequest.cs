namespace GymManagement.Core.Contracts.Authentication;


public record RegisterRequest(

    string Email,
    string UserName,
    string Password,
    string FirstName,
    string LastName
    );
