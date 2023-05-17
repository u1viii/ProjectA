using MediatR;
using ProjectA.Application.Abstractions.Services;
using ProjectA.Application.DTOs.Orders;
using System;
namespace ProjectA.Application.Features.Commands.Orders.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        IOrderService _service { get; }

        public CreateOrderCommandHandler(IOrderService service)
        {
            _service = service;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            DTO_OrderCreate orderCreate = new DTO_OrderCreate
            {
                CategoryIds = request.CategoryIds,
                DeadLine = request.DeadLine,
                Name = request.Name,
                Quantity = request.Quantity,
                Unit = request.Unit,
                Color = request.Color,
                Manufacturer = request.Manufacturer,
                Note = request.Note,
                PaymentId = request.PaymentId,
                Documents = request.Documents,
                Pictures = request.Pictures
            };
            await _service.CreateAsync(orderCreate);
            return new();
        }
    }
}
