using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.Application.Exceptions.UserExceptions
{
    public class TokenExpiredException :Exception, IBaseException
    {

        public int StatusCode => StatusCodes.Status419AuthenticationTimeout;

        public string ErrorMessage { get; }
        public TokenExpiredException() : base()
        {
            ErrorMessage = "Token vaxti bitib";
        }

        public TokenExpiredException(string message) : base(message)
        {
            ErrorMessage = message;
        }

        public TokenExpiredException(string message, Exception? innerException) : base(message, innerException)
        {
            ErrorMessage = message;
        }

    }
}
