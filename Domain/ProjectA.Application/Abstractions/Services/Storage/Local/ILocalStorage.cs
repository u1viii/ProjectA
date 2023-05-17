using Microsoft.AspNetCore.Http;

namespace ProjectA.Application.Abstractions.Services.Storage.Local
{
    public interface ILocalStorage:IStorage
    {
        Task CopyAsync(string path, IFormFile file);
    }
}
