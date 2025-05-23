using IIvT_ProjectAPI.Domain.Entities;
using IIvT_ProjectAPI.Infrastructure.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Infrastructure.Storage
{
    public class Storage
    {
        protected delegate bool HasFile(string pathOrContainerName, string fileName);

        protected async Task<string> FileRenameAsync(string pathOrContainerName, string fileName, HasFile hasFileMethod)
        {
            string newFileName = await Task.Run<string>(async () =>
            {
                string extension = Path.GetExtension(fileName);

                string oldName = Path.GetFileNameWithoutExtension(fileName);

                string newFileName = $"{NameOperations.CharacterRegulatory(oldName)}{extension}";

                if (hasFileMethod(pathOrContainerName, newFileName))
                {
                    string newFileNameWithDate = $"{oldName}_{DateTime.Now:yyyyMMddHHmmss}{extension}";
                    return newFileNameWithDate;
                }
                else
                    return newFileName;
            });

            return newFileName;
        }
    }
}
