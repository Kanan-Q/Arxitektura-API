using BlogApp.BL.DTO.User;
using BlogApp.BL.Services.Interfaces;
using BlogApp.Core.Entites.User;
using BlogApp.Core.Repositories.UserRepository;
using BlogApp.DAL.Context;
using BlogApp.DAL.Repositories;
using BlogBL.Exceptions.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.Services.Implements
{

    public class UserService : IUserService
    {
        public Task<string> CreateAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string username)
        {
            throw new NotImplementedException();
        }
    }
}

