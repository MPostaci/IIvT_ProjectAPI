using IIvT_ProjectAPI.Application.Abstractions.Storage;
using IIvT_ProjectAPI.Domain.Entities;
using IIvT_ProjectAPI.Infrastructure.Operations;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Infrastructure.Storage
{
    public class StorageService : IStorageService
    {
        readonly IStorage _storage;

        public StorageService(IStorage storage)
        {
            _storage = storage;
        }

        public string StorageName { get => _storage.GetType().Name; }

        public Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files)
            => _storage.UploadAsync(pathOrContainerName, files);

        public bool HasFile(string pathOrContainerName, string fileName)
            => _storage.HasFile(pathOrContainerName, fileName);

        public Task DeleteAsync(string path)
            => _storage.DeleteAsync(path);

        public List<string> GetFiles(string pathOrContainerName)
        {
            throw new NotImplementedException();
        }

        public FileTypeEnum GetFileType(string fileName)
        {
            string extension = Path.GetExtension(fileName).Replace(".", "");

            FileTypeEnum fileType = FileTypeOperations.GetFileTypeEnum(extension);

            return fileType;

        }
    }
}
