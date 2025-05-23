using IIvT_ProjectAPI.Application.Repositories;
using IIvT_ProjectAPI.Domain.Entities;
using IIvT_ProjectAPI.Persistence.Context;

namespace IIvT_ProjectAPI.Persistence.Repositories
{
    public class ProductMediaFileWriteRepository : WriteRepository<ProductMediaFile>, IProductMediaFileWriteRepository
    {
        public ProductMediaFileWriteRepository(IIvT_ProjectAPIDbContext context) : base(context)
        {
        }
    }
}
