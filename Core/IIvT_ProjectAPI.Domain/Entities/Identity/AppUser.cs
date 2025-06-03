using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public string FullName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiration { get; set; }

        //refresh token can be transferred to another table
        public ICollection<NewsItem> NewsItems { get; set; } = new List<NewsItem>();
        public ICollection<Announcement> Announcements { get; set; } = new List<Announcement>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Basket> Baskets { get; set; } = new List<Basket>();

        public ICollection<UserAddress> Addresses { get; set; }
    }
}
