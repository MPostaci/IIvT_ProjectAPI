using IIvT_ProjectAPI.Domain.Entities.Common;

namespace IIvT_ProjectAPI.Domain.Entities
{
    public class City : BaseEntity
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public ICollection<District> Districts { get; set; }
    }
}
