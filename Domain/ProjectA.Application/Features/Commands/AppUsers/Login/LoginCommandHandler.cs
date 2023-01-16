using MediatR;
using Microsoft.AspNetCore.Identity;
using ProjectA.Application.Abstractions.Token;
using ProjectA.Application.Exceptions;
using ProjectA.Application.Exceptions.UserExceptions;
using ProjectA.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.Application.Features.Commands.AppUsers.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly ITokenHandler _token;

        public LoginCommandHandler(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ITokenHandler token)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _token = token;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser user = await _userManager.FindByNameAsync(request.UsernameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(request.UsernameOrEmail);
            if (user == null)
                throw new UserNotFoundException();
            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (result.Succeeded)
            {
                return new()
                {
                    Token = _token.CreateAccessToken(50)
                };
            }
            throw new AuthenticationException();
        }
    }
}
