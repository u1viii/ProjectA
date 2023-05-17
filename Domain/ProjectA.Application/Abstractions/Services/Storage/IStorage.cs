using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.Application.Abstractions.Services.Storage
{
    public interface IStorage
    {
        Task<List<(string, string)>> UploadAsync(string pathOrContainerName, ICollection<IFormFile> files);
        Task<(string, string)> UploadAsync(string pathOrContainerName, IFormFile file);
        string RenameFile(string fileName);
        bool DeleteFile(string pathOrContainerName);
        List<string> GetFiles(string pathOrContainerName);
        bool HasFile(string pathOrContainerName);
    }
}
