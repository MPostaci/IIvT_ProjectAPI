using IIvT_ProjectAPI.Application.DTOs.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Abstractions.Services
{
    public interface IBasketService
    {
        Task<ListBasketDto> GetBasketAsync();
        Task<bool> AddItemToBasketAsync(string productId, int quantity);
        Task<bool> RemoveItemFromBasket(string productId);
        Task<bool> UpdateItemQuantityAsync(string productId, int quantity);
        Task<bool> ClearBasketAsync();
        Task<ListBasketDto> Checkout();
    }
}
