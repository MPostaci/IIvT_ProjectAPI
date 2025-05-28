using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.EventFile.UploadEventFile
{
    public class UploadEventFileCommandHandler : IRequestHandler<UploadEventFileCommandRequest, UploadEventFileCommandResponse>
    {
        public Task<UploadEventFileCommandResponse> Handle(UploadEventFileCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
