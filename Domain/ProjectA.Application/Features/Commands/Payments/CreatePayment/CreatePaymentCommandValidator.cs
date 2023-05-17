using FluentValidation;

namespace ProjectA.Application.Features.Commands.Payments.CreatePayment
{
    public class CreatePaymentCommandValidator:AbstractValidator<CreatePaymentCommandRequest>
    {
        public CreatePaymentCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull();
        }
    }
}
