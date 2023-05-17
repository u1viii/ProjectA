using MediatR;
using ProjectA.Application.Abstractions.Services;

namespace ProjectA.Application.Features.Commands.Orders.RemoveOrder
{
    public class RemoveOrderCommandHandler : IRequestHandler<RemoveOrderCommandRequest, RemoveOrderCommandResponse>
    {
        IOrderService _orderService { get; }

        public RemoveOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<RemoveOrderCommandResponse> Handle(RemoveOrderCommandRequest request, CancellationToken cancellationToken)
        {
            await _orderService.RemoveAsync(request.Id);
            return new();
        }
    }
}
