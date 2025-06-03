using IIvT_ProjectAPI.Domain.Entities.Common;
using IIvT_ProjectAPI.Domain.Entities.Identity;

namespace IIvT_ProjectAPI.Domain.Entities
{
    public class UserAddress : BaseEntity
    {
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public Guid AddressId { get; set; }
        public Address Address { get; set; }
    }
}
