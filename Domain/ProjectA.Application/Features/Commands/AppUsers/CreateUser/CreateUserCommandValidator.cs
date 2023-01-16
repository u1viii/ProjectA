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
            //RuleFor(x => x.Name).NotEmpty().MaximumLength(20);
            //RuleFor(x => x.Surname).NotEmpty().MaximumLength(25);
            //RuleFor(x => x.Username).NotEmpty().MaximumLength(30);
            //RuleFor(x => x.Email).NotEmpty().EmailAddress();
            //RuleFor(x => x.Password).NotEmpty();
            //RuleFor(x => x.RepeatPassword).NotEmpty().Equal(x=>x.Password);
        }   
    }
}
