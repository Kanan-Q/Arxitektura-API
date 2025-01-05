using BlogApp.BL.Services;
using Microsoft.AspNetCore.Mvc;
using BlogApp.BL.DTO.User;
using BlogApp.BL.Services.Interfaces;

namespace BlogAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IAuthService _service) : ControllerBase
    {
      
        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            await _service.RegisterAsync(dto);
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            return Ok(await _service.LoginAsync(dto));
        }
    }
}
