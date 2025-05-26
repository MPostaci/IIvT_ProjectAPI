using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Abstractions.Services
{
    public interface ICategoryService
    {
        Task<PagedResponse<ListCategoryDto>> GetAllCategories(PagedRequest request);
        Task<ListCategoryDto> GetByIdCategory(string id);
        Task<Dictionary<int, string>> GetContentTypes();
        Task<bool> CreateCategory(CreateCategoryDto createCategoryDto);
        Task<bool> DeleteCategory(string id);
        Task<bool> UpdateCategory(UpdateCategoryDto updateCategoryDto);
    }
}
