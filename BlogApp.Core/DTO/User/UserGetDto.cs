using BlogApp.BL.DTO.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Core.Entites;
namespace BlogApp.BL.DTO.User
{
    public class UserGetDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Fullname { get; set; }
        public string? Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
