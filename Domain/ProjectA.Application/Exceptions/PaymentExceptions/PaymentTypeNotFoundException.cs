using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.Application.Exceptions.PaymentExceptions
{
    public class PaymentTypeNotFoundException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status404NotFound;
        public string ErrorMessage { get; }
        public PaymentTypeNotFoundException()
        {
            ErrorMessage = "Odeme usulu artiq movcuddur";
        }

        public PaymentTypeNotFoundException(string message) : base(message)
        {
            ErrorMessage = message;
        }

        public PaymentTypeNotFoundException(string message, Exception? innerException) : base(message, innerException)
        {
            ErrorMessage = message;
        }


    }
}
