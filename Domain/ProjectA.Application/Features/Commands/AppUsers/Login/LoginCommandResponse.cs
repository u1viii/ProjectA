using ProjectA.Application.DTOs.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.Application.Features.Commands.AppUsers.Login
{
    public class LoginCommandResponse
    {
        public DTO_Token Token { get; set; }
    }
}
