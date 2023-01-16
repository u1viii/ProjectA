using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.Application.Exceptions.UserExceptions
{
    public class AuthenticationException:Exception
    {
        public AuthenticationException():base("Girish zamani bir xeta bash verdi"){}

        public AuthenticationException(string? message) : base(message)
        {
        }

        public AuthenticationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
