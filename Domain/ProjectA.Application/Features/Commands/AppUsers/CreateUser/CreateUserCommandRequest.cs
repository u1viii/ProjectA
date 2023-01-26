using MediatR;

namespace ProjectA.Application.Features.Commands.AppUsers.CreateUser
{
    public class CreateUserCommandRequest:IRequest<CreateUserCommandResponse>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsMale { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string? Position { get; set; }
        public string? TIN { get; set; }
        public bool? IsCustomer { get; set; }
        public bool? IsSupplier { get; set; }
        public string Number { get; set; }
        public List<Guid> CategoryIds { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
    }
}
