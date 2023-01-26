using MediatR;
using Microsoft.AspNetCore.Identity;
using ProjectA.Application.Abstractions.Services;
using ProjectA.Application.DTOs.AppUsers;
using ProjectA.Application.Exceptions;
using ProjectA.Core.Entities.Identity;

namespace ProjectA.Application.Features.Commands.AppUsers.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        IUserService _userService { get; }

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _userService.RegisterAsync(new DTO_UserRegister
            {
                CategoryIds = request.CategoryIds,
                Company = request.Company,
                Email = request.Email,
                IsCustomer = request.IsCustomer,
                IsMale = request.IsMale,
                IsSupplier = request.IsSupplier,
                Name = request.Name,
                Surname = request.Surname,
                Number = request.Number,
                Password = request.Password,
                Position = request.Position,
                RepeatPassword = request.RepeatPassword,
                TIN = request.TIN,
                Username = request.Username
            });
            return new();
            //throw new UserCreateFailedException();
        }
    }
}
