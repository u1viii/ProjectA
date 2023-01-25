using Microsoft.AspNetCore.Http;

namespace ProjectA.Application.Exceptions
{
    public interface IBaseException
    {
        int StatusCode { get; }
        string ErrorMessage { get; }
    }
}
