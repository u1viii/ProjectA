using Microsoft.AspNetCore.Http;
using ProjectA.Application.Abstractions.Services.Storage;

namespace ProjectA.Infrastructure.Services.Storage
{
    public class StorageService : IStorageService
    {
        IStorage _storage { get;}

        public string StorageName =>  _storage.GetType().Name;

        public StorageService(IStorage storage)
        {
            _storage = storage;
        }

        public bool DeleteFile(string pathOrContainerName)
            => _storage.DeleteFile(pathOrContainerName);

        public List<string> GetFiles(string pathOrContainerName)
            => _storage.GetFiles(pathOrContainerName);

        public bool HasFile(string pathOrContainerName)
            => _storage.HasFile(pathOrContainerName);
        

        public string RenameFile(string fileName)
            => _storage.RenameFile(fileName);
       
        public async Task<(string, string)> UploadAsync(string pathOrContainerName, IFormFile file)
            => await _storage.UploadAsync(pathOrContainerName, file);

        public async Task<List<(string, string)>> UploadAsync(string pathOrContainerName, ICollection<IFormFile> files)
            => await _storage.UploadAsync(pathOrContainerName, files);
    }
}
