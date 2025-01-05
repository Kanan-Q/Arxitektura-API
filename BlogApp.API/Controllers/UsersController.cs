using BlogApp.BL.DTO.User;
using BlogApp.BL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserCreateDto dto)
        {
            var userId = await _userService.AddUserAsync(dto);
            return CreatedAtAction(nameof(GetUserById), new { id = userId }, userId);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserUpdateDto dto)
        {
            await _userService.UpdateUserAsync(dto);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {

            await _userService.DeleteUserAsync(id);
            return NoContent(); 
        }
    }
}

