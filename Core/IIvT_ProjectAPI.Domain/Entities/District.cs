using IIvT_ProjectAPI.Domain.Entities.Common;

namespace IIvT_ProjectAPI.Domain.Entities
{
    public class District : BaseEntity
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int CityCode { get; set; }
        public Guid CityId { get; set; }
        public City City { get; set; }
        public ICollection<Neighborhood> Neighborhoods { get; set; }
    }
}
