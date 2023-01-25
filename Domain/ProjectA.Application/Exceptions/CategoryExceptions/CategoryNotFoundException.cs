using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.Application.Exceptions.CategoryExceptions
{
    public class CategoryNotFoundException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status404NotFound;

        public string ErrorMessage { get; }

        public CategoryNotFoundException()
        {
            ErrorMessage = "Bu kateqoriya movcud deyil";
        }

        public CategoryNotFoundException(string message) : base(message)
        {
            ErrorMessage = message;
        }

        public CategoryNotFoundException(string message, Exception? innerException) : base(message, innerException)
        {
            ErrorMessage = message;
        }


    }
}
