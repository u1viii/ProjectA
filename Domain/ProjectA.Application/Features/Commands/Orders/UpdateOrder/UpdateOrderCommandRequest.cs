using MediatR;
using Microsoft.AspNetCore.Http;

namespace ProjectA.Application.Features.Commands.Orders.UpdateOrder
{
    public class UpdateOrderCommandRequest : IRequest<UpdateOrderCommandResponse>
    {
        public Guid? Id { get; set; }
        public IEnumerable<Guid> CategoryIds { get; set; } = null!;
        public DateTime DeadLine { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string? Unit { get; set; }
        public string? Color { get; set; }
        public string? Manufacturer { get; set; }
        public string? Note { get; set; }
        public ICollection<Guid>? DeletedFileIds { get; set; }
        public ICollection<IFormFile>? Documents { get; set; }
        public ICollection<IFormFile>? Pictures { get; set; }
        public Guid PaymentId { get; set; }
    }
}
