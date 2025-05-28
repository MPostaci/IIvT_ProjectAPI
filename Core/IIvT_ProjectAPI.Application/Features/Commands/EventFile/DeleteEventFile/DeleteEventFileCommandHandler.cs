using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.EventFile.DeleteEventFile
{
    public class DeleteEventFileCommandHandler : IRequestHandler<DeleteEventFileCommandRequest, DeleteEventFileCommandResponse>
    {
        public Task<DeleteEventFileCommandResponse> Handle(DeleteEventFileCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
