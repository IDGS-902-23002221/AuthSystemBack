using AuthenticationAPI.DTO;
using AuthenticationAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // se llama la variable de servicio y se hace el proceso de registro
            var result = await _service.RegisterAsync(dto);

            //si el registro fue exitoso 
            if(!result.Success)
                //sino
                return BadRequest(result);

            // se registra
            return Ok(result);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // se llama la variable de servicio y se hace el proceso de registro
            var result = await _service.LoginAsync(dto);

            //si el registro fue exitoso 
            if (!result.Success)
                //sino
                return BadRequest(result);

            // se registra
            return Ok(result);
        }

        [Authorize]
        [HttpGet("me")]
        public IActionResult Me()
        {
            return Ok(new
            {
                Id = User.FindFirst("sub")?.Value,
                Email = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value
                       ?? User.FindFirst(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email)?.Value,
                Nombre = User.Identity?.Name,
                Roles = User.Claims
                    .Where(c => c.Type == System.Security.Claims.ClaimTypes.Role)
                    .Select(c => c.Value)
            });
        }

        [Authorize]
        [HttpPost("logOut")]
        public async Task<IActionResult> LogOut()
        {
            var id = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrWhiteSpace(id))
                return Unauthorized();

            await _service.LogOutAsync(id);

            return Ok("sesion cerrada");


        }
    }
}
