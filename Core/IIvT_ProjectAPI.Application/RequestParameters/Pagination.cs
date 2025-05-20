using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.RequestParameters
{
    public record Pagination
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
        public int Skip => (Page - 1) * Size;
        public int Take => Size;
        public bool HasPrevious => Page > 1;
        public bool HasNext => Page < TotalPages;
        public int TotalPages { get; set; } = 0;
        public int TotalCount { get; set; } = 0;
    }
}
