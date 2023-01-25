using Microsoft.AspNetCore.Http;

namespace ProjectA.Application.Exceptions.UserExceptions
{
    public class AuthenticationException:Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status400BadRequest;
        public string ErrorMessage { get; }
        public AuthenticationException():base()
        {
            ErrorMessage = "Girish zamani bir xeta bash verdi";
        }

        public AuthenticationException(string message) : base(message)
        {
            ErrorMessage = message;
        }

        public AuthenticationException(string message, Exception? innerException) : base(message, innerException)
        {
            ErrorMessage = message;
        }

    }
}
