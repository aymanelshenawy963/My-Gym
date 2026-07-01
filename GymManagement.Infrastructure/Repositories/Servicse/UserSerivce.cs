using GymManagement.Core.Abstractions;
using GymManagement.Core.Abstractions.Const;
using GymManagement.Core.Contracts.Users;
using GymManagement.Core.Entities;
using GymManagement.Core.Errors;
using GymManagement.Core.Interfaces.IServices;
using GymManagement.Infrastructure.Data;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Infrastructure.Repositories.Servicse;

public class UserSerivce(UserManager<ApplicationUser> userManager,
    IRoleService roleService,
    ApplicationDbContext context) : IUserSerivce
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly IRoleService _roleService = roleService;
    private readonly ApplicationDbContext _context = context;


    public async Task<IEnumerable<UserResponse>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await (from user in _context.Users
               join userRole in _context.UserRoles
               on user.Id equals userRole.UserId
               join role in _context.Roles
               on userRole.RoleId equals role.Id into roles
               where !roles.Any(x => x.Name == DefaultRoles.Member.Name)
               select new
               {
                   user.Id,
                   user.FirstName,
                   user.LastName,
                   user.UserName,
                   user.Email,
                   user.IsDisabled,
                   Roles = roles.Select(r => r.Name!).ToList()
               }
               )
                .GroupBy(user => new { user.Id, user.FirstName, user.LastName,user.UserName, user.Email, user.IsDisabled })
                .Select(user => new UserResponse
                (
                    user.Key.Id,
                    user.Key.FirstName,
                    user.Key.LastName,
                    user.Key.UserName,
                    user.Key.Email,
                    user.Key.IsDisabled,
                    user.SelectMany(x => x.Roles)
                ))
               .ToListAsync(cancellationToken);

    public async Task<Result<UserResponse>> GetAsync(string userId)
    {

        if (await _userManager.FindByIdAsync(userId) is not { } user)
            return Result.Failure<UserResponse>(UsersErrors.UserNotFound);

        var userRoles = await _userManager.GetRolesAsync(user);

        var response = (user, userRoles).Adapt<UserResponse>();
        return Result.Success(response);

    }

    public async Task<Result<UserResponse>> AddAsync(CreateUserRequest request, CancellationToken cancellationToken = default)
    {
        var emailIsExists = await _userManager.Users.AnyAsync(x => x.Email == request.Email);

        if (emailIsExists)
            return Result.Failure<UserResponse>(UsersErrors.DuplicatedEmail);

        var userNameIsExists = await _userManager.Users.AllAsync(x=>x.UserName == request.UserName);

        if (userNameIsExists)
            return Result.Failure<UserResponse>(UsersErrors.DuplicatedUserName);

        var allowedRoles = await _roleService.GetAllAsync(cancellationToken: cancellationToken);

        if (request.Roles.Except(allowedRoles.Select(x => x.Name)).Any())
            return Result.Failure<UserResponse>(UsersErrors.InvalidRoles);

        var user = request.Adapt<ApplicationUser>();

        var result = await _userManager.CreateAsync(user, request.Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRolesAsync(user, request.Roles);

            var response = (user, request.Roles).Adapt<UserResponse>();
            return Result.Success(response);
        }

        var error = result.Errors.First();

        return Result.Failure<UserResponse>(new Error(error.Code, error.Description, StatusCodes.Status400BadRequest));
    }

    public async Task<Result> UpdateAsync(string id, UpdateUserRequest request, CancellationToken cancellationToken = default)
    {
        var emailIsExists = await _userManager.Users.AnyAsync(x => x.Email == request.Email && x.Id != id, cancellationToken);

        if (emailIsExists)
            return Result.Failure(UsersErrors.DuplicatedEmail);

        var UserNameIsExists = await _userManager.Users.AnyAsync(x => x.UserName == request.UserName && x.Id != id, cancellationToken);

        if (UserNameIsExists)
            return Result.Failure(UsersErrors.DuplicatedUserName);

        var allowedRoles = await _roleService.GetAllAsync(cancellationToken: cancellationToken);

        if (request.Roles.Except(allowedRoles.Select(x => x.Name)).Any())
            return Result.Failure(UsersErrors.InvalidRoles);

        if (await _userManager.FindByIdAsync(id) is not { } user)
            return Result.Failure(UsersErrors.UserNotFound);

        user = request.Adapt(user);

        var result = await _userManager.UpdateAsync(user);

        if (result.Succeeded)
        {
            // Remove existing roles
            await _context.UserRoles
                .Where(ur => ur.UserId == id)
                .ExecuteDeleteAsync(cancellationToken);

            await _userManager.AddToRolesAsync(user, request.Roles);
            return Result.Success();
        }

        var error = result.Errors.First();

        return Result.Failure(new Error(error.Code, error.Description, StatusCodes.Status400BadRequest));
    }

    public async Task<Result> ToggleStatus(string id)
    {
        if (await _userManager.FindByIdAsync(id) is not { } user)
            return Result.Failure<UserResponse>(UsersErrors.UserNotFound);

        user.IsDisabled = !user.IsDisabled;

        var result = await _userManager.UpdateAsync(user);

        if (result.Succeeded)
            return Result.Success();

        var error = result.Errors.First();
        return Result.Failure(new Error(error.Code, error.Description, StatusCodes.Status400BadRequest));

    }

    public async Task<Result> Unlock(string id)
    {
        if (await _userManager.FindByIdAsync(id) is not { } user)
            return Result.Failure<UserResponse>(UsersErrors.UserNotFound);

        var result = await _userManager.SetLockoutEndDateAsync(user, null);

        if (result.Succeeded)
            return Result.Success();

        var error = result.Errors.First();
        return Result.Failure(new Error(error.Code, error.Description, StatusCodes.Status400BadRequest));

    }
    public async Task<Result<UserProfileResponse>> GetProfileAsync(string userId)
    {
        var user = await _userManager.Users
            .Where(x => x.Id == userId)
            .ProjectToType<UserProfileResponse>()
            .SingleAsync();

        return Result.Success(user);
    }

    public async Task<Result> UpdateProfileAsync(string userId, UpdateProfileRequest request)
    {
        await _userManager.Users
            .Where(x => x.Id == userId)
            .ExecuteUpdateAsync(setters =>
            setters
                   .SetProperty(x => x.FirstName, request.FirstName)
                   .SetProperty(x => x.LastName, request.LastName)
                   );

        return Result.Success();
    }

    public async Task<Result> ChangePasswordAsync(string userId, ChangePasswordRequest request)
    {
        var user = await _userManager.FindByIdAsync(userId);

        var result = await _userManager.ChangePasswordAsync(user!, request.CurrntPassword, request.NewPassword);

        if (result.Succeeded)
            return Result.Success();

        var error = result.Errors.First();

        return Result.Failure(new Error(error.Code, error.Description, StatusCodes.Status400BadRequest));
    }
}
