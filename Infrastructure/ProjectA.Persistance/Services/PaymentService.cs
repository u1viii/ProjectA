using ProjectA.Application;
using ProjectA.Application.Abstractions.Services;
using ProjectA.Application.Exceptions.PaymentExceptions;
using ProjectA.Application.Repositories;
using ProjectA.Core.Entities;

namespace ProjectA.Persistance.Services
{
    public class PaymentService : IPaymentService
    {

        IPaymentReadRepository _paymentRead { get; }
        IPaymentWriteRepository _paymentWrite { get; }
        IUnitOfWorks _unitOfWorks { get; }
        public PaymentService(IPaymentReadRepository paymentRead, IPaymentWriteRepository paymentWrite, IUnitOfWorks unitOfWorks)
        {
            _paymentRead = paymentRead;
            _paymentWrite = paymentWrite;
            _unitOfWorks = unitOfWorks;
        }
        public async Task CreateAsync(string name)
        {
            if (_paymentRead.Table.Any(t => t.Type == name)) throw new PaymentTypeExistException();
            bool result = await _paymentWrite.AddAsync(new Payment { Type = name });
            await _unitOfWorks.SaveChangesAsync();
            // TODO: Exception throwla
            // if (!result) throw new InternalServerErrorException();
        }

        public void Delete(Guid id)
        {
            if (!_paymentRead.Table.Any(t => t.Id == id)) throw new PaymentTypeNotFoundException();
            _paymentWrite.Remove(id.ToString());
        }

        public void Delete(Payment payment)
        {
            bool result = _paymentWrite.Remove(payment);
        }

        public IQueryable<Payment> GetPaymentList()
            => _paymentRead.GetAll();

        public Task UpdateAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
