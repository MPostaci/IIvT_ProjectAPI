using IIvT_ProjectAPI.Application.Common.Marker;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Commands.NewsItem.DeleteNewsItem
{
    public class DeleteNewsItemCommandRequest : IRequest<DeleteNewsItemCommandResponse>, ICommandRequest
    {
        public string Id { get; set; }
    }
}