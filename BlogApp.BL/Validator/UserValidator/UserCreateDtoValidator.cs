using BlogApp.BL.DTO.User;
using BlogApp.Core.Repositories.UserRepository;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBL.Validator.UserValidator
{
    public class UserCreateDtoValidator:AbstractValidator<RegisterDto>
    {
        //readonly IUserRepository _repo;
        public UserCreateDtoValidator()
        {
            //_repo=repo;
            RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress() ;
            RuleFor(x => x.Username).NotEmpty().NotNull();



        }
    }
}
