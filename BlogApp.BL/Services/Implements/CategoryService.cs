using BlogApp.BL.DTO.Category;
using BlogApp.BL.Services.Interfaces;
using BlogApp.Core.Entites.Category;
using BlogApp.Core.Repositories;
using BlogApp.Core.Repositories.CategoryRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Services.Implements
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> AddCategoryAsync(CategoryCreateDto dto)
        {
            var category = new Category
            {
                Name = dto.Name,
                Icon = dto.Icon
            };

            await _repo.AddCategoryAsync(category);
            await _repo.SaveAsync();
            return category.Id;
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            var category = await _repo.GetCategoryByIdAsync(id);
            if (category == null) return null;

            return new Category
            {
                Id = category.Id,
                Name = category.Name,
                Icon = category.Icon
            };
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            var categories = await _repo.GetAllCategoriesAsync();
            return categories.Select(c => new Category
            {
                Id = c.Id,
                Name = c.Name,
                Icon = c.Icon
            });
        }

        public async Task UpdateCategoryAsync(CategoryUpdateDto dto)
        {
            var category = await _repo.GetCategoryByIdAsync(dto.Id);
            if (category == null) throw new Exception("Category not found");

            category.Name = dto.Name;
            category.Icon = dto.Icon;

            _repo.UpdateCategory(category);
            await _repo.SaveAsync();
        }


        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _repo.GetCategoryByIdAsync(id);
            if (category == null)
                throw new Exception("Category not found");

            await _repo.RemoveCategoryAsync(id);
            await _repo.SaveAsync();
        }


    }
}

