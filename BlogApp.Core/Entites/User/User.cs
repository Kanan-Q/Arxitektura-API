﻿using BlogApp.Core.Entites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Entites.User
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsMale { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public int Role { get; set; } = 2;
    }
}
