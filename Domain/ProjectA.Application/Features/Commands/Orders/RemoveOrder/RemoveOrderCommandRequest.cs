using MediatR;

namespace ProjectA.Application.Features.Commands.Orders.RemoveOrder
{
    public class RemoveOrderCommandRequest:IRequest<RemoveOrderCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
