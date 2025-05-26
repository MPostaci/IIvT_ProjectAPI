using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Exceptions
{
    public class NotFoundAnnouncementException : Exception
    {
        public NotFoundAnnouncementException() : base("Announcement not found.")
        {
        }

        public NotFoundAnnouncementException(string? message) : base(message)
        {
        }

        public NotFoundAnnouncementException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
