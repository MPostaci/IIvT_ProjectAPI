using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Common.Pagination
{
    public class PagedResponse<T>
    {
        public PagedResponse() { }

        // 2) make them settable
        public IReadOnlyList<T> Items { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }

        public PagedResponse(
            IReadOnlyList<T> items,
            int count,
            int pageNumber,
            int pageSize
            )
        {
            Items = items;
            TotalCount = count;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }
    }
}
