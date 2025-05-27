using IIvT_ProjectAPI.Application.Common.Marker;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Commands.NewsItem.UpdateNewsItem
{
    public class UpdateNewsItemCommandRequest : IRequest<UpdateNewsItemCommandResponse>, ICommandRequest
    {
    }
}