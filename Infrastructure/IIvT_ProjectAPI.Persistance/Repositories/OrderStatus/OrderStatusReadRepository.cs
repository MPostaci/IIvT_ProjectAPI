using IIvT_ProjectAPI.Application.Repositories;
using IIvT_ProjectAPI.Domain.Entities;
using IIvT_ProjectAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Persistence.Repositories
{
    public class OrderStatusReadRepository : ReadRepository<OrderStatus>, IOrderStatusReadRepository
    {
        public OrderStatusReadRepository(IIvT_ProjectAPIDbContext context) : base(context)
        {
        }
    }
}
