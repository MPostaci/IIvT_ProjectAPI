using IIvT_ProjectAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.DTOs.Category
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ContentType { get; set; }
    }
}
