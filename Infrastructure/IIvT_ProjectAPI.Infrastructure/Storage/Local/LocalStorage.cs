﻿using IIvT_ProjectAPI.Application.Abstractions.Storage.Local;
using IIvT_ProjectAPI.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace IIvT_ProjectAPI.Infrastructure.Storage.Local
{
    public class LocalStorage : Storage, ILocalStorage
    {
        readonly IWebHostEnvironment _webHostEnvironment;

        public LocalStorage(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task DeleteAsync(string path)
            => File.Delete($"{_webHostEnvironment.WebRootPath}/{path}");

        public List<string> GetFiles(string path)
        {
            throw new NotImplementedException();
        }


        public bool HasFile(string path, string fileName)
            => File.Exists($"{path}\\{fileName}");

        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string path, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);

            if(!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            List<(string fileName, string pathOrContainerName)> datas = new();

            foreach (var file in files)
            {
                string fileNewName = await FileRenameAsync(uploadPath, file.FileName, HasFile);

                await CopyFileAsync($"{uploadPath}\\{fileNewName}", file);

                datas.Add((fileNewName, $"{path}/{fileNewName}"));
            }

            return datas;
        }

        private async Task<bool> CopyFileAsync(string path, IFormFile file)
        {
            try
            {
                await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);

                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;
            }
            catch (Exception ex)
            {
                // todo: Log the exception (ex) here
                throw ex;
            }
        }
    }
}
