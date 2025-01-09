using BlogApp.BL.DTO.Category;
using BlogApp.BL.Helpers;
using BlogApp.BL.Services.Interfaces;
using BlogApp.Core.Entites.Category;
using BlogApp.Core.Repositories.CategoryRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController(ICategoryRepository _repo) : ControllerBase
    {

        [HttpGet("Get")]
        public async Task<IActionResult> Get(string s)
        {
            return Ok(HashHelper.HashPassword(s));
        }
        [HttpGet("Password")]
        public async Task<IActionResult> Get(string str, string password)
        {
            return Ok(HashHelper.VerifyHashedPassword(str, password));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repo.GetAll().ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post(Category category)
        {
            await _repo.Addasync(category);
            await _repo.SaveAsync();
            return Ok(category.Id);

        }
    }
}
