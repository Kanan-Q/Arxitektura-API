using AutoMapper;
using BlogApp.BL.DTO.User;
using BlogApp.BL.Helpers;
using BlogApp.Core.Entites.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBL.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterDto, User>().ForMember(x => x.PasswordHash, x => x.MapFrom(y => HashHelper.HashPassword(y.Password)));
        }

    }
}
