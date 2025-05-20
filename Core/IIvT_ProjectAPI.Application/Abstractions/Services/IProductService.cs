using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Abstractions.Services
{
    public interface IProductService
    {
        Task<PagedResponse<ListProductDto>> GetAllProductsAsync(PagedRequest request);

        Task<ListProductDto> GetByIdProductAsync(string id);

        Task<bool> CreateProductAsync(CreateProductDto product);

        Task UpdateProductAsync();

        Task DeleteProductAsync();
    }
}
