using MediatR;
using ProjectA.Application.Abstractions.Services;
using ProjectA.Application.DTOs.AppUsers;
using ProjectA.Application.DTOs.Token;

namespace ProjectA.Application.Features.Commands.AppUsers.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        IUserService _userService { get; }

        public LoginCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            DTO_Token token = await _userService.LoginAsync(new DTO_UserLogin
            {
                UsernameOrEmail = request.UsernameOrEmail,
                Password = request.Password
            });
            return new()
            {
                Token = token
            };
        }
    }
}
