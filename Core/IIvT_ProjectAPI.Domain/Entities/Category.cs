using IIvT_ProjectAPI.Domain.Entities.Common;

namespace IIvT_ProjectAPI.Domain.Entities
{
    public class Category : SoftDeleteEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ContentTypeEnum ContentType { get; set; }
        public ICollection<NewsItem> NewsItem { get; set; }
        public ICollection<Announcement> Announcement { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
