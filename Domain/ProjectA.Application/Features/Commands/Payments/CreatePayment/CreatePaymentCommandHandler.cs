using MediatR;
using ProjectA.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.Application.Features.Commands.Payments.CreatePayment
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommandRequest, CreatePaymentCommandResponse>
    {
        IPaymentService _payment { get; }

        public CreatePaymentCommandHandler(IPaymentService payment)
        {
            _payment = payment;
        }

        public async Task<CreatePaymentCommandResponse> Handle(CreatePaymentCommandRequest request, CancellationToken cancellationToken)
        {
            await _payment.CreateAsync(request.Name);
            return new();
        }
    }
}
