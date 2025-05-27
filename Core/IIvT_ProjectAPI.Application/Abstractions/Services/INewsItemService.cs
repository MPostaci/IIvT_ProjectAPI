using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.NewsItem;
using IIvT_ProjectAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Abstractions.Services
{
    public interface INewsItemService
    {
        /// <summary>
        /// Retrieves a list of news items.
        /// </summary>
        /// <param name="pagedRequest"> The pagination request parameters.</param>
        /// <returns>A list of news items.</returns>
        Task<PagedResponse<ListNewsItemDto>> GetAllNewsItemsAsync(PagedRequest pagedRequest);
        
        /// <summary>
        /// Retrieves a specific news item by its ID.
        /// </summary>
        /// <param name="id">The ID of the news item.</param>
        /// <returns>The news item with the specified ID.</returns>
        Task<ListNewsItemDto> GetNewsItemByIdAsync(string id);
        
        /// <summary>
        /// Retrives a list of news items by publisher ID.
        /// </summary>
        /// <param name="pagedRequest"> The pagination request parameters.</param>
        /// <param name="publisherId"> The ID of the publisher whose news items are to be retrieved.</param>
        /// <returns>A list of news items associated with the specified publisher ID.</returns>
        Task<PagedResponse<ListNewsItemDto>> GetNewsItemsByPublisherIdAsync(string publisherId, PagedRequest pagedRequest);
        
        /// <summary>
        /// Retrieves a list of news items by category ID.
        /// </summary>
        /// <param name="categoryId"> The ID of the category whose news items are to be retrieved.</param>
        /// <param name="pagedRequest"> The pagination request parameters.</param>
        /// <returns>A list of news items associated with the specified category ID.</returns>
        Task<PagedResponse<ListNewsItemDto>> GetNewsItemsByCategoryIdAsync(string categoryId, PagedRequest pagedRequest);
        
        /// <summary>
        /// Creates a new news item.
        /// </summary>
        /// <param name="createNewsItemDto">The news item to create.</param>
        /// <returns>The created news item.</returns>
        Task<ListNewsItemDto> CreateNewsItemAsync(CreateNewsItemDto createNewsItemDto);

        
        /// <summary>
        /// Updates an existing news item.
        /// </summary>
        /// <param name="updateNewsItemDto">The news item to update.</param>
        /// <returns>The updated news item.</returns>
        Task<ListNewsItemDto> UpdateNewsItemAsync(UpdateNewsItemDto updateNewsItemDto);

        /// <summary>
        /// Deletes a news item by its ID.
        /// </summary>
        /// <param name="id">The ID of the news item to delete.</param>
        /// <returns>A boolean indicating whether the deletion was successful.</returns>
        Task<bool> DeleteNewsItemAsync(string id);

        /// <summary>
        /// Uploads files associated with a news item.
        /// </summary>
        /// <param name="files"> The files to upload.</param>
        /// <param name="newsItemId"> The ID of the news item to associate the files with.</param>
        /// <returns>A boolean indicating whether the upload was successful.</returns>
        Task<bool> UploadFilesAsync(string newsItemId, IFormFileCollection files);

        /// <summary>
        /// Removes a file associated with a news item.
        /// </summary>
        /// <param name="fileId"> The ID of the file to remove.</param>
        /// <param name="newsItemId"> The ID of the news item associated with the file.</param>
        /// <returns>A boolean indicating whether the removal was successful.</returns>
        Task<bool> RemoveFileAsync(string newsItemId, string fileId);

        /// <summary>

        Task<bool> ChangeShowcaseFile(string newsItemId, string fileId);
    }
}
