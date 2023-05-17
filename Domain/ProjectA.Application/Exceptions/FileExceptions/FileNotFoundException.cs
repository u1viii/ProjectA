using Microsoft.AspNetCore.Http;

namespace ProjectA.Application.Exceptions.FileExceptions
{
    public class FileNotFoundException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status404NotFound;

        public string ErrorMessage { get; }
        public FileNotFoundException()
        {
            ErrorMessage = "Bele fayl tapilmadi";
        }

        public FileNotFoundException(string message) : base(message)
        {
            ErrorMessage = message;
        }

        public FileNotFoundException(string message, Exception? innerException) : base(message, innerException)
        {
            ErrorMessage = message;
        }


    }
}
