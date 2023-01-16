using MediatR;
using Microsoft.AspNetCore.Identity;
using ProjectA.Application.Exceptions;
using ProjectA.Core.Entities.Identity;

namespace ProjectA.Application.Features.Commands.AppUsers.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly UserManager<AppUser> _userManager;

        public CreateUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            IdentityResult result = await _userManager.CreateAsync(new AppUser { Name = request.Name, Surname = request.Surname, IsMale=request.IsMale, Email=request.Email, UserName=request.Username}, request.Password);
            CreateUserCommandResponse response = new CreateUserCommandResponse() { Succeeded = result.Succeeded};
            if (result.Succeeded)
                response.Message = "User created";
            else
            {
                foreach (var item in result.Errors)
                {
                    response.Message += $"{item.Code} - {item.Description} <br>";
                }
            }
            return response;
            //throw new UserCreateFailedException();
        }
    }
}
