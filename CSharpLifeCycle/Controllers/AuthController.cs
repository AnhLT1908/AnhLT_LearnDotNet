using CSharpLifeCycle.DTOs;
using CSharpLifeCycle.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace CSharpLifeCycle.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;
        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest dto)
        {
            var user = await _auth.RegisterAsync(dto.Username, dto.Password, dto.FullName);
            if (user == null) return Conflict("Username existed");
            return Ok(new { user.Id, user.Username, user.FullName, user.Role });
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest dto)
        {
            var res = await _auth.LoginAsync(dto.Username, dto.Password);
            if (res == null) return Unauthorized("Wrong account or password");
            return Ok(res);
        }
        [HttpGet("profile")]
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var username = User.Identity?.Name;
            if (string.IsNullOrEmpty(username)) return Unauthorized();
            var user = await _auth.GetByUsernameAsync(username);
            if (user == null) return NotFound();
            return Ok(new { user.Username, user.FullName, user.Role });
        }
    }
}