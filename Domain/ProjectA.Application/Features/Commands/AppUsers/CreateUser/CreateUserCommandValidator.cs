using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.Application.Features.Commands.AppUsers.CreateUser
{
    public class CreateUserCommandValidator:AbstractValidator<CreateUserCommandRequest>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(15);
            RuleFor(x => x.Surname).NotEmpty().NotNull().MaximumLength(15);
            RuleFor(x => x.Username).NotEmpty().MaximumLength(20);
            RuleFor(x => x.Position).MaximumLength(30);
            RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress();
            RuleFor(x => x.Number).NotEmpty().NotNull().Length(12);
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.RepeatPassword).NotEmpty().Equal(x => x.Password);
        }   
    }
}
