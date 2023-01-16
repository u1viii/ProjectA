using Microsoft.AspNetCore.Identity;
using ProjectA.Core.Entities.Identity;

namespace ProjectA.Application.Features.Commands.AppUsers.CreateUser
{
    public class CreateUserCommandResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}
