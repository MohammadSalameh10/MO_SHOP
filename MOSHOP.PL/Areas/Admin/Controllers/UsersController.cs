using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOSHOP.BLL.Services.Interfaces;

namespace MOSHOP.PL.Areas.Admin.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("")]

        public async Task<IActionResult> GetAllUser()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] string id)
        {
            var user = await _userService.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpPatch("Block/{id}")]

        public async Task<IActionResult> BlockUser([FromRoute] string userId, [FromBody] int days)
        {
            var result = await _userService.BlockUserAsync(userId, days);
            if (!result)
            {
                return NotFound(new { message = "User not found or could not be blocked." });
            }
            return Ok(new { message = "User blocked successfully." });
        }

        [HttpPatch("UnBlock/{id}")]
        public async Task<IActionResult> UnBlockUser([FromRoute] string userId)
        {
            var result = await _userService.UnBlockUserAsync(userId);
            if (!result)
            {
                return NotFound(new { message = "User not found or could not be unblocked." });
            }
            return Ok(new { message = "User unblocked successfully." });
        }

        [HttpGet("IsBlocked/{id}")]
        public async Task<IActionResult> IsUserBlocked([FromRoute] string userId)
        {
            var isBlocked = await _userService.IsBlockUserAsync(userId);
            return Ok(new { userId, isBlocked });
        }

    }
}
