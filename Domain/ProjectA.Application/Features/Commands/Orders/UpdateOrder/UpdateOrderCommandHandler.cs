using MediatR;
using ProjectA.Application.Abstractions.Services;
using ProjectA.Application.DTOs.Orders;
using ProjectA.Application.Exceptions.OrderExceptions;
using ProjectA.Application.Repositories;
using ProjectA.Core.Entities;

namespace ProjectA.Application.Features.Commands.Orders.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommandRequest, UpdateOrderCommandResponse>
    {
        IOrderService _orderService { get; }
        ICategoryService _categoryService { get; }
        public UpdateOrderCommandHandler(IOrderService service, ICategoryService categoryService, IOrderFileReadRepository orderRepo)
        {
            _orderService = service;
            _categoryService = categoryService;
        }
        public async Task<UpdateOrderCommandResponse> Handle(UpdateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            DTO_OrderUpdate orderUpdate = new DTO_OrderUpdate
            {
                CategoryIds = request.CategoryIds,
                Color = request.Color,
                DeadLine = request.DeadLine,
                DeletedFileIds = request.DeletedFileIds,
                Documents = request.Documents,
                Id = request.Id,
                Manufacturer = request.Manufacturer,
                Name = request.Name,
                Note = request.Note,
                PaymentId = request.PaymentId,
                Pictures = request.Pictures,
                Quantity = request.Quantity,
                Unit = request.Unit
            };
            await _orderService.UpdateAsync(orderUpdate);
            return new();
        }
    }
}
