using BlogApp.Core.Entites.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.BL.DTO.Category;
namespace BlogApp.Core.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task AddCategoryAsync(Category category);
        Task<Category?> GetCategoryByIdAsync(int id);
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        void UpdateCategory(Category category);
        Task RemoveCategoryAsync(int id);
        Task<int> SaveAsync();

    }
}
