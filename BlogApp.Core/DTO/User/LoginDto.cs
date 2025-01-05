using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BL.DTO.User
{
    public class LoginDto
    {
        public string UsernameorEmail { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
    }
}
