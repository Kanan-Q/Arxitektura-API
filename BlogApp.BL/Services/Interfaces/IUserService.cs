using BlogApp.BL.DTO.User;
using BlogApp.Core.Entites.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Services.Interfaces
{
    public interface IUserService
    {
        public Task<string> CreateAsync();
        public Task DeleteAsync(string username);
    }
}
