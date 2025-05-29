using IIvT_ProjectAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.DTOs.Event
{
    public class EventMediaFileDto
    {
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public string Storage { get; set; }
        public FileTypeEnum FileTpye { get; set; }
        public string EventId { get; set; }
    }
}
