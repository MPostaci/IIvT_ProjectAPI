using IIvT_ProjectAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Abstractions.Storage
{
    public interface IStorageService : IStorage
    {
        public string StorageName { get; }

        public FileTypeEnum GetFileType(string fileName);
    }
}
