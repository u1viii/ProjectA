using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.Application.Features.Commands.Payments.CreatePayment
{
    public class CreatePaymentCommandRequest:IRequest<CreatePaymentCommandResponse>
    {
        public string Name { get; set; } = null!;
    }
}
