using IIvT_ProjectAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Infrastructure.Operations
{
    public static class FileTypeOperations
    {
        public static FileTypeEnum GetFileTypeEnum(string fileType)
        {
            return fileType.ToLower() switch
            {
                "jpg" => FileTypeEnum.Image,
                "jpeg" => FileTypeEnum.Image,
                "png" => FileTypeEnum.Image,
                "tiff" => FileTypeEnum.Image,
                "mp4" => FileTypeEnum.Video,
                "avi" => FileTypeEnum.Video,
                "mov" => FileTypeEnum.Video,
                "wmv" => FileTypeEnum.Video,
                "pdf" => FileTypeEnum.Document,
                "doc" => FileTypeEnum.Document,
                "docx" => FileTypeEnum.Document,
                "xls" => FileTypeEnum.Document,
                "xlsx" => FileTypeEnum.Document,
                "ppt" => FileTypeEnum.Document,
                "pptx" => FileTypeEnum.Document,
                "txt" => FileTypeEnum.Document,
                "csv" => FileTypeEnum.Document,
                _ => FileTypeEnum.Other
            };
        }
    }
}
