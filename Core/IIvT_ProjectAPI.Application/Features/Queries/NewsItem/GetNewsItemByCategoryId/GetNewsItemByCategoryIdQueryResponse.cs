using IIvT_ProjectAPI.Application.DTOs.NewsItem;
using IIvT_ProjectAPI.Domain.Entities;

namespace IIvT_ProjectAPI.Application.Features.Queries.NewsItem.GetNewsItemByCategoryId
{
    public class GetNewsItemByCategoryIdQueryResponse
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public ContentTypeEnum ContentType { get; set; }
        public string PublisherFullName { get; set; }
        public string PublisherId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public IEnumerable<NewsItemMediaFileDto> Files { get; set; }
    }
}