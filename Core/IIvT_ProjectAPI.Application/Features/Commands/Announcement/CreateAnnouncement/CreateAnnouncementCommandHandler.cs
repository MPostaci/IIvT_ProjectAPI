using AutoMapper;
using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.DTOs.Announcement;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.Announcement.CreateAnnouncement
{
    public class CreateAnnouncementCommandHandler : IRequestHandler<CreateAnnouncementCommandRequest, CreateAnnouncementCommandResponse>
    {
        readonly IAnnouncementService _announcementService;
        readonly IMapper _mapper;

        public CreateAnnouncementCommandHandler(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        public async Task<CreateAnnouncementCommandResponse> Handle(CreateAnnouncementCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _announcementService.CreateAnnouncement(_mapper.Map<CreateAnnouncementDto>(request));

            return new()
            {
                Success = result,
                Message = result ? "Announcement created successfully" : "An error occured while creating announcement"
            };
        }
    }
}
