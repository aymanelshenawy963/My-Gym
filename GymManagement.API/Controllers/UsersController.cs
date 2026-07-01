using GymManagement.Core.Abstractions;
using GymManagement.Core.Abstractions.Const;
using GymManagement.Core.Contracts.Users;
using GymManagement.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.API.Controllers;


[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = nameof(DefaultRoles.Admin))]
public class UsersController(IUserSerivce userSerivce) : ControllerBase
{
    private readonly IUserSerivce _userSerivce = userSerivce;

    [HttpGet("")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await _userSerivce.GetAllAsync(cancellationToken));
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> Get([FromRoute] string userId)
    {
        var result = await _userSerivce.GetAsync(userId);
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpPost("")]
    public async Task<IActionResult> Add([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        var result = await _userSerivce.AddAsync(request, cancellationToken);
        return result.IsSuccess ? CreatedAtAction(nameof(Get), new { userId = result.Value.Id }, result.Value) : result.ToProblem();
    }
    [HttpPut("{userId}")]
    public async Task<IActionResult> Update([FromRoute] string userId, [FromBody] UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var result = await _userSerivce.UpdateAsync(userId, request, cancellationToken);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }

    [HttpPut("{userId}/toggle-status")]
    public async Task<IActionResult> ToggleStatus([FromRoute] string userId)
    {
        var user = await _userSerivce.ToggleStatus(userId);
        return user.IsSuccess ? NoContent() : user.ToProblem();
    }

    [HttpPut("{userId}/unlock")]
    public async Task<IActionResult> Unlock([FromRoute] string userId)
    {
        var user = await _userSerivce.Unlock(userId);
        return user.IsSuccess ? NoContent() : user.ToProblem();
    }
}
