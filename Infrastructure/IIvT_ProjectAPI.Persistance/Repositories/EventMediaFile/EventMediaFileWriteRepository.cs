using IIvT_ProjectAPI.Application.Repositories;
using IIvT_ProjectAPI.Domain.Entities;
using IIvT_ProjectAPI.Persistence.Context;

namespace IIvT_ProjectAPI.Persistence.Repositories
{
    public class EventMediaFileWriteRepository : WriteRepository<EventMediaFile>, IEventMediaFileWriteRepository
    {
        public EventMediaFileWriteRepository(IIvT_ProjectAPIDbContext context) : base(context)
        {
        }
    }
}
