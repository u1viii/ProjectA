using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.Application.Exceptions
{
    public class UserNotFoundException : Exception, IBaseException
    {
        public int StatusCode { get => StatusCodes.Status404NotFound; }
        public string ErrorMessage { get; set; }
        
        public UserNotFoundException()
        {
            ErrorMessage = "Istifadeci tapilmadi";
        }

        public UserNotFoundException(string? message) : base(message)
        {
            ErrorMessage = message;
        }

        public UserNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
            ErrorMessage = message;
        }

    }
}
