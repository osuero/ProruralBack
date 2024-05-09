using Microsoft.AspNetCore.Mvc;
using ProRualBackEnd.Models;
using Services.AuthInterface;

namespace ProRualBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var (IsSuccess, Token, UserId) = await _authService.AuthenticateAsync(loginRequest.Username, loginRequest.Password);

            if (!IsSuccess)
            {
                return Unauthorized("Invalid username or password.");
            }

            return Ok(new { Token, UserId });
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            // Perform server-side logout logic here if necessary.
            // For JWT/stateless auth, this might simply be a placeholder.

            // Log the logout action for auditing, if applicable.
            // _logger.LogInformation("User logged out.");

            // You can return a simple success response as there's no specific action needed for JWT.
            return Ok(new { message = "Logout successful." });
        }
        [HttpGet("is-email-confirmed/{username}")]
        public async Task<IActionResult> IsEmailConfirmed(string username)
        {
            try
            {
                var isEmailConfirmed = await _authService.IsEmailConfirmedAsync(username);
                return Ok(new { Username = username, IsEmailConfirmed = isEmailConfirmed });
            }
            catch (System.Exception ex)
            {
                // Log exception details here if logging is set up
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest changePasswordRequest)
        {
            if (changePasswordRequest == null || string.IsNullOrEmpty(changePasswordRequest.UserId) || string.IsNullOrEmpty(changePasswordRequest.NewPassword))
            {
                return BadRequest("Invalid request");
            }

            var result = await _authService.ChangePasswordAsync(changePasswordRequest.UserId, changePasswordRequest.NewPassword);
                if (result)
            {
                return Ok(true);
            }
            else
            {
                return BadRequest(false);
            }
        }
    }
}
