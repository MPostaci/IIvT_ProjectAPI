using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.DTOs.Category
{
    public class UpdateCategoryDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ContentType { get; set; }
    }
}
