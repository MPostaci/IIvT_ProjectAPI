using AutoMapper;
using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.DTOs.Basket;
using IIvT_ProjectAPI.Application.Exceptions;
using IIvT_ProjectAPI.Application.Repositories;
using IIvT_ProjectAPI.Domain.Entities;
using IIvT_ProjectAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Persistence.Services
{
    public class BasketService : IBasketService
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly UserManager<AppUser> _userManager;
        readonly IBasketItemReadRepository _basketItemReadRepository;
        readonly IBasketItemWriteRepository _basketItemWriteRepository;
        readonly IBasketReadRepository _basketReadRepository;
        readonly IBasketWriteRepository _basketWriteRepository;
        readonly IMapper _mapper;
        readonly IProductService _productService;

        public BasketService(
            IBasketItemReadRepository basketItemReadRepository, IBasketItemWriteRepository basketItemWriteRepository,
            IBasketReadRepository basketReadRepository, IBasketWriteRepository basketWriteRepository, IMapper mapper, IProductService productService, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            _basketItemReadRepository = basketItemReadRepository;
            _basketItemWriteRepository = basketItemWriteRepository;
            _basketReadRepository = basketReadRepository;
            _basketWriteRepository = basketWriteRepository;
            _mapper = mapper;
            _productService = productService;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        private async Task<string> GetCurrentUserIdAsync()
        {
            var userName = _httpContextAccessor.HttpContext?.User.Identity?.Name
                ?? throw new NotFoundUserException();

            var user = await _userManager.FindByNameAsync(userName)
                ?? throw new NotFoundUserException();

            return user.Id;
        }

        private async Task<Basket> GetUserBasketAsync()
        {
            var userId = await GetCurrentUserIdAsync();


            Basket? basket = await _basketReadRepository.Table
                .Include(x => x.BasketItems)
                .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.UserId == userId);
            if (basket == null)
            {
                basket = new Basket
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    BasketItems = new List<BasketItem>()
                };
                await _basketWriteRepository.AddAsync(basket);

            }

            return basket;
        }

        public async Task<ListBasketDto> GetBasketAsync()
        {
            Basket basket = await GetUserBasketAsync();

            return _mapper.Map<ListBasketDto>(basket);

        }

        public async Task<bool> AddItemToBasketAsync(string productId, int quantity)
        {
            Basket basket = await GetUserBasketAsync();


            var product = await _productService.GetByIdProductAsync(productId)
                ?? throw new NotFoundProductException();


            BasketItem? basketItem = basket.BasketItems.FirstOrDefault(x => x.ProductId == Guid.Parse(productId) && x.BasketId == basket.Id);
            
            if (basketItem == null)
            {
                await _basketItemWriteRepository.AddAsync(
                    basketItem = new BasketItem
                    {
                        Id = Guid.NewGuid(),
                        ProductId = Guid.Parse(productId),
                        Quantity = quantity,
                        Price = product.Price,
                        BasketId = basket.Id,
                    });

                basket.BasketItems.Add(basketItem);
            }
            else
            {
                basketItem.Quantity += quantity;
                _basketItemWriteRepository.Update(basketItem);
            }

            return true;
        }

        public async Task<bool> RemoveItemFromBasket(string productId)
        {
            if (!Guid.TryParse(productId, out var pid))
                throw new ArgumentException("Invalid product ID", nameof(productId));

            var basket = await GetUserBasketAsync();

            var itemToRemove = basket.BasketItems
                .FirstOrDefault(x => x.ProductId == pid)
                ?? throw new NotFoundBasketItemException();

            _basketItemWriteRepository.Remove(itemToRemove);


            return true;
        }

        public async Task<bool> UpdateItemQuantityAsync(string productId, int quantity)
        {
            if (!Guid.TryParse(productId, out var pid))
                throw new ArgumentException("Invalid product ID", nameof(productId));

            var basket = await GetUserBasketAsync();

            var basketItem = basket.BasketItems
                .FirstOrDefault(x => x.ProductId == pid) 
                ?? throw new NotFoundBasketItemException();

            if (quantity <= 0)
            {
                _basketItemWriteRepository.Remove(basketItem);
            }
            else
            {
                basketItem.Quantity = quantity;
                _basketItemWriteRepository.Update(basketItem);
            }


            return true;
        }

        public async Task<ListBasketDto> Checkout()
        {
            var basket = await GetBasketAsync();

            await _basketItemWriteRepository.Table
                .Where(x => x.Basket.UserId == GetCurrentUserIdAsync().Result)
                .ForEachAsync(x => _basketItemWriteRepository.Remove(x));

            return basket;
        }

        public async Task<bool> ClearBasketAsync()
        {
            var basket = await GetUserBasketAsync();

            await _basketItemReadRepository.Table
                .Where(x => x.BasketId == basket.Id)
                .ForEachAsync(x => _basketItemWriteRepository.Remove(x));


            await _basketWriteRepository.RemoveAsync(basket.Id.ToString());


            return true;
        }


    }
}
