using IIvT_ProjectAPI.Application.Repositories;
using IIvT_ProjectAPI.Domain.Entities;
using IIvT_ProjectAPI.Persistence.Context;

namespace IIvT_ProjectAPI.Persistence.Repositories
{
    public class AnnouncementMediaFileWriteRepository : WriteRepository<AnnouncementMediaFile>, IAnnouncementMediaFileWriteRepository
    {
        public AnnouncementMediaFileWriteRepository(IIvT_ProjectAPIDbContext context) : base(context)
        {
        }
    }
}
