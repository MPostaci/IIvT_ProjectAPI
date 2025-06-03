using IIvT_ProjectAPI.Domain.Entities.Common;

namespace IIvT_ProjectAPI.Domain.Entities
{
    public class Neighborhood : BaseEntity
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int DistrictCode { get; set; }
        public Guid DistrictId { get; set; }
        public District District { get; set; }
    }
}
