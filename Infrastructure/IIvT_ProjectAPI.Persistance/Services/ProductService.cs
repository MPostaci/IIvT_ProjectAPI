using AutoMapper;
using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Product;
using IIvT_ProjectAPI.Application.Exceptions;
using IIvT_ProjectAPI.Application.Repositories;
using IIvT_ProjectAPI.Domain.Entities;

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

        public async Task<ListProductDto> GetByIdProductAsync(string id)
        {
            return await _productReadRepository.GetByIdAsync(id, false).ContinueWith(t =>
            {
                if (t.Result == null)
                    throw new NotFoundProductException();
                return _mapper.Map<ListProductDto>(t.Result);
            });
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

        public async Task<bool> UpdateProductAsync(UpdateProductDto product)
        {
            Product oldProduct = await _productReadRepository.GetByIdAsync(product.Id) 
                ?? throw new NotFoundProductException();

            oldProduct.Name = product.Name;
            oldProduct.Stock = product.Stock;
            oldProduct.Price = product.Price;

            var result = _productWriteRepository.Update(oldProduct);

            if (result)
                result = await _productWriteRepository.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteProductAsync(string id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id)
                ?? throw new NotFoundProductException();
            var result = _productWriteRepository.Remove(product);

            if (result)
                result = await _productWriteRepository.SaveChangesAsync();

            return result;
        }
    }
}
