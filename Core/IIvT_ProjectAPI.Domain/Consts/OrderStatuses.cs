using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Domain.Consts
{
    public static class OrderStatusConstants
    {
        public static readonly Guid Pending = Guid.Parse("00000000-0000-0000-0000-000000000001");
        public static readonly Guid Processing = Guid.Parse("00000000-0000-0000-0000-000000000002");
        public static readonly Guid Shipped = Guid.Parse("00000000-0000-0000-0000-000000000003");
        public static readonly Guid Completed = Guid.Parse("00000000-0000-0000-0000-000000000004");
        public static readonly Guid Cancelled = Guid.Parse("00000000-0000-0000-0000-000000000005");
    }
}
