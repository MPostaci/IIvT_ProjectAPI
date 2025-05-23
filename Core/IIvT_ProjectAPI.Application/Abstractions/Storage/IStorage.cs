using IIvT_ProjectAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Abstractions.Storage
{
    public interface IStorage
    {
        Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files);

        Task DeleteAsync(string path);

        List<string> GetFiles(string pathOrContainerName);

        bool HasFile(string pathOrContainerName, string fileName);
    }
}
