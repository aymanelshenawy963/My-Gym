using GymManagement.Core.Abstractions;
using GymManagement.Core.Contracts.Roles;
using GymManagement.Core.Entities;
using GymManagement.Core.Errors;
using GymManagement.Core.Interfaces.IServices;
using GymManagement.Infrastructure.Data;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace GymManagement.Infrastructure.Repositories.Servicse;

public class RoleService(RoleManager<ApplicationRole> roleManager, ApplicationDbContext context) : IRoleService
{
    private readonly RoleManager<ApplicationRole> _roleManager = roleManager;
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<RoleResponse>> GetAllAsync(bool includeDisabled = false, CancellationToken cancellationToken = default) =>
        await _roleManager.Roles
        .Where(x => !x.IsDefault && (!x.IsDeleted || includeDisabled))
        .ProjectToType<RoleResponse>()
        .ToListAsync(cancellationToken); 

    public async Task<Result<RoleResponse>> AddAsync(RoleRequest request)
    {
        var roleIsExist = await _roleManager.RoleExistsAsync(request.Name);
        if (roleIsExist)
            return Result.Failure<RoleResponse>(RoleErros.DuplicatedRole);

        var role = new ApplicationRole
        {
            Name = request.Name,
            ConcurrencyStamp = Guid.CreateVersion7().ToString(),
        };

        var result = await _roleManager.CreateAsync(role);

        if (result.Succeeded)
        {
            await _context.SaveChangesAsync();

            var response = new RoleResponse(role.Id, role.Name, role.IsDeleted);
            return Result.Success(response);
        }

        var errors = result.Errors.First();
        return Result.Failure<RoleResponse>(new Error(errors.Code, errors.Description, StatusCodes.Status400BadRequest));

    }

    public async Task<Result> UpdateAsync(string id, RoleRequest request)
    {
        var roleIsExist = await _roleManager.Roles.AnyAsync(x => x.Name == request.Name && x.Id != id);

        if (roleIsExist)
            return Result.Failure<RoleResponse>(RoleErros.DuplicatedRole);

        if (await _roleManager.FindByIdAsync(id) is not { } role)
            return Result.Failure<RoleResponse>(RoleErros.RoleNotFound);

        role.Name = request.Name;

        var result = await _roleManager.UpdateAsync(role);

        if (result.Succeeded)
        {
            await _context.SaveChangesAsync();
            return Result.Success();
        }

        var errors = result.Errors.First();
        return Result.Failure<RoleResponse>(new Error(errors.Code, errors.Description, StatusCodes.Status400BadRequest));
    }

    public async Task<Result> ToggleStatusAsync(string id)
    {
        if (await _roleManager.FindByIdAsync(id) is not { } role)
            return Result.Failure<RoleResponse>(RoleErros.RoleNotFound);

        role.IsDeleted = !role.IsDeleted;

        await _roleManager.UpdateAsync(role);
        return Result.Success();

    }
}
