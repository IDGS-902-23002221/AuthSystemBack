using AuthenticationAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        private UsersController(IUserService service)
        {
            _userService = service;
        }

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_userService.GetAllAsync());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult> GetById(string id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await _userService.DeleteAsync(id));
        }

        

    }
}
