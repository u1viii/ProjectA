using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.Application.DTOs.AppUsers
{
    public class DTO_UserLogin
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
