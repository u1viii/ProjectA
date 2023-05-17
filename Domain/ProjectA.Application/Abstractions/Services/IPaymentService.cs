using ProjectA.Core.Entities;

namespace ProjectA.Application.Abstractions.Services
{
    public interface IPaymentService
    {
        IQueryable<Payment> GetPaymentList();
        Task CreateAsync(string name);
        Task UpdateAsync(string name);
        void Delete(Guid id);
        void Delete(Payment payment);
    }
}
