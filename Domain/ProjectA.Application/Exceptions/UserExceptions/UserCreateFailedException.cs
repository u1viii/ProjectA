using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.Application.Exceptions.UserExceptions
{
    public class UserCreateFailedException : Exception
    {
        public UserCreateFailedException() : base("Unexpected error happend when creating user")
        {
        }

        public UserCreateFailedException(string? message) : base(message)
        {
        }

        public UserCreateFailedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
