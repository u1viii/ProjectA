using MediatR;
using ProjectA.Application.Abstractions.Services;
using ProjectA.Application.DTOs.AppUsers;

namespace ProjectA.Application.Features.Commands.AppUsers.RefreshTokenLogin
{
    public class RefreshTokenLoginCommandHandler : IRequestHandler<RefreshTokenLoginCommandRequest, RefreshTokenLoginCommandResponse>
    {
        IUserService _userService { get; }

        public RefreshTokenLoginCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<RefreshTokenLoginCommandResponse> Handle(RefreshTokenLoginCommandRequest request, CancellationToken cancellationToken)
        {
            return new()
            {
                Token = await _userService.RefreshTokenLoginAsync(new DTO_UserRefreshTokenLogin { RefreshToken = request.RefreshToken })
            };
        }
    }
}
