using AutoMapper;
using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Product;
using IIvT_ProjectAPI.Application.Repositories;
using IIvT_ProjectAPI.Application.Util;
using IIvT_ProjectAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Persistence.Services
{
    public class ProductService : IProductService
    {
        readonly IMapper _mapper;
        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;

        public ProductService(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IMapper mapper)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _mapper = mapper;
        }


        public async Task<PagedResponse<ListProductDto>> GetAllProductsAsync(PagedRequest request)
        {
            var query = _productReadRepository.GetAll(false);

            return await query.ToPagedListAsync<Product, ListProductDto>(_mapper, request);
        }

        public async Task<bool> CreateProductAsync(CreateProductDto product)
        {
            var result = await _productWriteRepository.AddAsync(_mapper.Map<Product>(product));

            if (result)
                result = await _productWriteRepository.SaveChangesAsync();

            if (!result)
                throw new Exception("Product could not be created");

            return result;

        }

        public Task DeleteProductAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetByIdProductAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductAsync()
        {
            throw new NotImplementedException();
        }
    }
}
