using ProjectA.Application.DTOs.Orders;

namespace ProjectA.Application.Abstractions.Services
{
    public interface IOrderService
    {
        Task CreateAsync(DTO_OrderCreate orderCreate);
        Task UpdateAsync(DTO_OrderUpdate orderUpdate);
        Task RemoveAsync(Guid id);
    }
}
