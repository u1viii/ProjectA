using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectA.Application.Abstractions.Services;
using ProjectA.Application.Enums;
using ProjectA.Application.Features.Commands.AppUsers.CreateUser;
using ProjectA.Application.Features.Commands.AppUsers.Login;

namespace ProjectA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IMediator _mediator { get; }
        //RoleManager<IdentityRole> _roleManager { get; }
        IUserService _userService { get; }
        public UsersController(IMediator mediator, IUserService userService)
        {
            _mediator = mediator;
            //_roleManager = roleManager;
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> GoogleLogin(string token)
        {
            await _userService.GoogleAuth(token);
            return Ok();
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> RefreshTokenLogin(LoginCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        //[HttpPost("[action]")]
        //public async Task<IActionResult> CreateRoles()
        //{
        //    foreach (string item in Enum.GetValues(typeof(UserRoles)))
        //    {
        //        if (await _roleManager.RoleExistsAsync(item))
        //        {
        //            await _roleManager.CreateAsync(new IdentityRole(item));
        //        }
        //    }
        //    return Ok();
        //}
    }
}
