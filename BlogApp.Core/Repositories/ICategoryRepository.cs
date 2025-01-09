using BlogApp.Core.Entites.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.BL.DTO.Category;
namespace BlogApp.Core.Repositories.CategoryRepository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    { }
    
}
