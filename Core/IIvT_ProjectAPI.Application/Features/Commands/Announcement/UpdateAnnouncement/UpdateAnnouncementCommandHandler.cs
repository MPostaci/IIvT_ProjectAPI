using AutoMapper;
using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.DTOs.Announcement;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.Announcement.UpdateAnnouncement
{
    public class UpdateAnnouncementCommandHandler : IRequestHandler<UpdateAnnouncementCommandRequest, UpdateAnnouncementCommandResponse>
    {
        readonly IAnnouncementService _announcementService;
        readonly IMapper _mapper;

        public UpdateAnnouncementCommandHandler(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        public async Task<UpdateAnnouncementCommandResponse> Handle(UpdateAnnouncementCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _announcementService.UpdateAnnouncement(_mapper.Map<UpdateAnnouncementDto>(request));

            return new UpdateAnnouncementCommandResponse
            {
                IsSuccess = result,
                Message = result ? "Announcement updated successfully." : "Failed to update announcement."
            };
        }
    }
}
