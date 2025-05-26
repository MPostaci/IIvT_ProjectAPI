using AutoMapper;
using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Category;
using IIvT_ProjectAPI.Application.Repositories;
using IIvT_ProjectAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Persistence.Services
{
    public class CategoryService : ICategoryService
    {
        readonly ICategoryReadRepository _categoryReadRepository;
        readonly ICategoryWriteRepository _categoryWriteRepository;
        readonly IMapper _mapper;

        public CategoryService(ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository, IMapper mapper)
        {
            _categoryReadRepository = categoryReadRepository;
            _categoryWriteRepository = categoryWriteRepository;
            _mapper = mapper;
        }

        public Task<PagedResponse<ListCategoryDto>> GetAllCategories(PagedRequest request)
        {
            var query = _categoryReadRepository.GetAll(false);

            return query.ToPagedListAsync<Category, ListCategoryDto>(_mapper, request);
        }

        public async Task<ListCategoryDto> GetByIdCategory(string id)
        {
            var category = await _categoryReadRepository.GetByIdAsync(id);

            return _mapper.Map<ListCategoryDto>(category);
        }

        public Task<Dictionary<int, string>> GetContentTypes()
        {
            ContentTypeEnum[] contentTypes = (ContentTypeEnum[])Enum.GetValues(typeof(ContentTypeEnum));

            var contentTypeDictionary = contentTypes.ToDictionary(
                ct => (int)ct,
                ct => ct.ToString()
            );

            return Task.FromResult(contentTypeDictionary);
        }

        public async Task<bool> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            return await _categoryWriteRepository.AddAsync(_mapper.Map<Category>(createCategoryDto));
        }

        public async Task<bool> DeleteCategory(string id)
        {
            var category = await _categoryReadRepository.GetByIdAsync(id);

            category.IsDeleted = true;

            return true;
        }

        public async Task<bool> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var category = await _categoryReadRepository.GetByIdAsync(updateCategoryDto.Id);

            return _categoryWriteRepository.Update(_mapper.Map(updateCategoryDto, category));
        }
    }
}
