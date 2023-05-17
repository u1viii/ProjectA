using Microsoft.AspNetCore.Http;

namespace ProjectA.Application.Exceptions.OrderExceptions
{
    public class OrderNotFoundException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status404NotFound;

        public string ErrorMessage { get; }
        public OrderNotFoundException()
        {
            ErrorMessage = "Sifarish tapilmadi";
        }

        public OrderNotFoundException(string message) : base(message)
        {
            ErrorMessage = message;
        }

        public OrderNotFoundException(string message, Exception? innerException) : base(message, innerException)
        {
            ErrorMessage = message;
        }


    }
}
