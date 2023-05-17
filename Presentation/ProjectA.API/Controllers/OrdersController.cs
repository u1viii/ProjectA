using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectA.Application.Features.Commands.Orders.CreateOrder;
using ProjectA.Application.Features.Commands.Orders.RemoveOrder;
using ProjectA.Application.Features.Commands.Orders.UpdateOrder;

namespace ProjectA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IMediator _mediator { get; }

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateOrderCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm]UpdateOrderCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(RemoveOrderCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
