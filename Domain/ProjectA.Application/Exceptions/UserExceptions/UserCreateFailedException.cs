using Microsoft.AspNetCore.Http;

namespace ProjectA.Application.Exceptions.UserExceptions
{
    public class UserCreateFailedException : Exception, IBaseException
    {
        public int StatusCode { get => StatusCodes.Status400BadRequest; }
        public string ErrorMessage { get; }
        public UserCreateFailedException() : base()
        {
            ErrorMessage = "User yaradan zaman xeta bash verdi";
        }

        public UserCreateFailedException(string message) : base(message)
        {
            ErrorMessage = message;
        }

        public UserCreateFailedException(string message, Exception? innerException) : base(message, innerException)
        {
            ErrorMessage = message;
        }
    }
}
