using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.Application.Exceptions.CommonExceptions
{
    public class BadRequestException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status400BadRequest;

        public string ErrorMessage { get; }
        public BadRequestException()
        {
            ErrorMessage = "Bad Request";
        }

        public BadRequestException(string message) : base(message)
        {
            ErrorMessage = message;
        }

        public BadRequestException(string message, Exception? innerException) : base(message, innerException)
        {
            ErrorMessage = message;
        }


    }
}
