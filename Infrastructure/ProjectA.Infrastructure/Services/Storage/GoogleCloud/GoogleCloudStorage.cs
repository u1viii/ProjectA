using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ProjectA.Application.Abstractions.Services.Storage.GoogleCloud;

namespace ProjectA.Infrastructure.Services.Storage.GoogleCloud
{
    public class GoogleCloudStorage : IGoogleCloudStorage
    {
        GoogleCredential _credential { get; }
        string _bucketName { get; }
        public GoogleCloudStorage()
        {
            ConfigurationManager manager = new();
            manager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ProjectA.API"));
            manager.AddJsonFile("appsettings.json");
            _credential = GoogleCredential.FromFile(manager["GCPStorageAuthFile"]);
            _bucketName = manager["GoogleCloudStorageBucketName"];
        }
        public bool DeleteFile(string pathOrContainerName)
        {
            using (var storageClient = StorageClient.Create(_credential))
                storageClient.DeleteObject(_bucketName, pathOrContainerName);
            return true;
        }

        public List<string> GetFiles(string pathOrContainerName)
        {
            throw new NotImplementedException();
        }

        public bool HasFile(string pathOrContainerName)
        {
            throw new NotImplementedException();
        }

        public string RenameFile(string fileName)
        {
            string extension = Path.GetExtension(fileName);
            string pureName = Path.GetFileNameWithoutExtension(fileName);
            if (pureName.Length > 63)
                pureName = pureName.Substring(0, 63);
            return pureName + Guid.NewGuid() + extension;
        }

        public async Task<List<(string, string)>> UploadAsync(string path, ICollection<IFormFile> files)
        {
            List<(string, string)> filesList = new List<(string, string)>();
            foreach (var item in files)
            {
                filesList.Add(await UploadAsync(path, item));
            }
            return filesList;
        }

        public async Task<(string, string)> UploadAsync(string pathOrContainerName, IFormFile file)
        {
            pathOrContainerName = Path.Combine(_bucketName,pathOrContainerName);
            await using MemoryStream memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            using var storageClient = StorageClient.Create(_credential);
            string newName = RenameFile(file.FileName);
            var uploadedFile = await storageClient.UploadObjectAsync(pathOrContainerName, newName, file.ContentType, memoryStream);
            await memoryStream.FlushAsync();
            return (newName, pathOrContainerName);
        }
    }
}
