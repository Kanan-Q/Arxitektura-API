using BlogApp.BL.DTO.User;
using BlogApp.Core.Entites.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Repositories.UserRepository
{


    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetUserByUserNameAsync(string username);
        Task AddUserAsync(UserCreateDto dto);
        Task<IEnumerable<UserGetDto>> GetAllUsersAsync();
        Task SaveAsync();
    }
}

