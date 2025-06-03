using IIvT_ProjectAPI.Application.DTOs.Address;
using IIvT_ProjectAPI.Application.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.DTOs.Event
{
    public class ListEventDto
    {
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public GetAddressDto Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ListCategoryDto Category { get; set; }
        public string PublisherId { get; set; }
        public string PublisherFullName { get; set; }
        public ICollection<EventMediaFileDto> Files { get; set; } = new List<EventMediaFileDto>();

    }
}
