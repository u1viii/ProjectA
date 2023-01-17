using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectA.Application.Abstractions.Token;
using ProjectA.Application.DTOs.Token;
using ProjectA.Application.Exceptions;
using ProjectA.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.Application.Features.Commands.AppUsers.RefreshTokenLogin
{
    public class RefreshTokenLoginCommandHandler : IRequestHandler<RefreshTokenLoginCommandRequest, RefreshTokenLoginCommandResponse>
    {
        UserManager<AppUser> _userManager { get; }
        ITokenHandler _token { get; }

        public RefreshTokenLoginCommandHandler(ITokenHandler token, 
            UserManager<AppUser> userManager)
        {
            _token = token;
            _userManager = userManager;
        }

        public async Task<RefreshTokenLoginCommandResponse> Handle(RefreshTokenLoginCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == request.RefreshToken);

            if (user != null && user.RefreshTokenExpires > DateTime.UtcNow)
            {
                DTO_Token token = _token.CreateAccessToken(45);
                user.RefreshTokenExpires = token.Expires.AddMinutes(15);
                user.RefreshToken = token.RefreshToken;
                await _userManager.UpdateAsync(user);
                return new()
                {
                    Token = token
                };
            }
            throw new UserNotFoundException();
        }
    }
}
