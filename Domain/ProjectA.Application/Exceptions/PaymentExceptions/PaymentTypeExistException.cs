using Microsoft.AspNetCore.Http;

namespace ProjectA.Application.Exceptions.PaymentExceptions
{
    public class PaymentTypeExistException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status400BadRequest;

        public string ErrorMessage { get; }
        public PaymentTypeExistException()
        {
            ErrorMessage = "Bu odeme usulu artiq movcuddur";
        }

        public PaymentTypeExistException(string message) : base(message)
        {
            ErrorMessage = message;
        }

        public PaymentTypeExistException(string message, Exception? innerException) : base(message, innerException)
        {
            ErrorMessage = message;
        }

    }
}
