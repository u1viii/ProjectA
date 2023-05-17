using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectA.Application.Features.Commands.Payments.CreatePayment;

namespace ProjectA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodsController : ControllerBase
    {
        IMediator _mediator { get; }

        public PaymentMethodsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreatePaymentMethod(CreatePaymentCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
