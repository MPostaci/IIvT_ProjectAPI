using IIvT_ProjectAPI.Application.Common.Marker;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IIvT_ProjectAPI.Application.Features.Commands.NewsItem.CreateNewsItem
{
    public class CreateNewsItemCommandRequest : IRequest<CreateNewsItemCommandResponse>, ICommandRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string CategoryId { get; set; }
        public IFormFileCollection? Files { get; set; }
    }
}