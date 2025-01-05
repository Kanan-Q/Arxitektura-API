using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.DTO.Category
{
    public class CategoryGetDto
    {
        public int Id  { get; set; }
        public string Name { get; set; }
        //public static implicit operator CategoryGetDto(BlogApp.Core.Entites.Category category)
        //{
        //    return new CategoryGetDto
        //    {
        //        Id = category.Id,
        //        CategoryName = category.CategoryName,
        //    };
        //}
        
    }
}
