using Microsoft.AspNetCore.Http;

namespace IIvT_ProjectAPI.Application.DTOs.NewsItem
{
    public class CreateNewsItemDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string CategoryId { get; set; }
        public IFormFileCollection? Files { get; set; }
    }
}
