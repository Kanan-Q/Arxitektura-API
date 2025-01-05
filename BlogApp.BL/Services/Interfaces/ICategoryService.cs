using BlogApp.BL.DTO.Category;
using BlogApp.Core.Entites.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<int> AddCategoryAsync(CategoryCreateDto dto);
        Task<Category?> GetCategoryByIdAsync(int id);
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task UpdateCategoryAsync(CategoryUpdateDto dto);
        Task DeleteCategoryAsync(int id);
    }
}
