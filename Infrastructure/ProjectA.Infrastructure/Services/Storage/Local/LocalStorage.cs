using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ProjectA.Application.Abstractions.Services.Storage.Local;

namespace ProjectA.Infrastructure.Services.Storage.Local
{
    public class LocalStorage : ILocalStorage
    {
        IWebHostEnvironment _env { get; }

        public LocalStorage(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task CopyAsync(string path, IFormFile file)
        {
            await using FileStream fs = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(fs);
            await fs.FlushAsync();
        }

        public bool DeleteFile(string path)
        {
            path = Path.Combine(_env.WebRootPath, path);
            if (HasFile(path))
            {
                File.Delete(path);
                return true;
            }
            return false;
            
        }

        public List<string> GetFiles(string path)
            => Directory.GetFiles(path).ToList();

        public bool HasFile(string path)
            => File.Exists(path);

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

        public async Task<(string,string)> UploadAsync(string path, IFormFile file)
        {
            string oldPath = path;
            path = Path.GetFullPath(Path.Combine(_env.WebRootPath, path));
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            string newName = RenameFile(file.FileName);
            await CopyAsync(Path.Combine(path, newName), file);
            return (newName, oldPath);
        }
    }
}
