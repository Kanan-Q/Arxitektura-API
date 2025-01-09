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

    public class CategoryService(ICategoryRepository _repo) : ICategoryService
    {
        public async Task<int> CreateAsync(CategoryCreateDto dto)
        {
            Category cat = dto;
            await _repo.Addasync(cat);
            await _repo.SaveAsync();
            return cat.Id;

        }

        public async Task<IEnumerable<CategoryGetDto>> GetAllAsync()
        {
            return await _repo.GetAll().Select(x => new CategoryGetDto
            {
                Id = x.Id,
                Name = x.Name,
            }).ToListAsync();
        }
    }
}

