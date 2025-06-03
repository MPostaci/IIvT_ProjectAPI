using IIvT_ProjectAPI.Application.DTOs.Address;
using IIvT_ProjectAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.DTOs.Event
{
    public class CreateEventDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CategoryId { get; set; }
        public string PublisherId { get; set; }
        public string? AddressId { get; set; }
        public CreateAddressDto? Location { get; set; }
    }
}
