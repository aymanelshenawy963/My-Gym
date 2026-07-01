using GymManagement.API.Extentsions;
using GymManagement.Core.Contracts.Users;
using GymManagement.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GymManagement.Core.Abstractions;

namespace GymManagement.API.Controllers;

[Route("me")]
[ApiController]
[Authorize]
public class AccountController(IUserSerivce userSerivce) : ControllerBase
{
    private readonly IUserSerivce _userSerivce = userSerivce;

    [HttpGet("")]
    public async Task<IActionResult> Info()
    {
        var result = await _userSerivce.GetProfileAsync(User.GetUserId()!);
        return Ok(result.Value);
    }

    [HttpPut("info")]
    public async Task<IActionResult> Info([FromBody] UpdateProfileRequest request)
    {
        await _userSerivce.UpdateProfileAsync(User.GetUserId()!, request);
        return NoContent();
    }

    [HttpPut("change-password")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
    {
        var result = await _userSerivce.ChangePasswordAsync(User.GetUserId()!, request);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }
}
