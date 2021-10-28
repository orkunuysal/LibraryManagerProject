using BasketManager.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketManager.API.Service
{
    public class BasketService : IBasketService
    {
        private readonly IDistributedCache _redisCache;

        public BasketService(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }

        public async Task<Basket> GetBasket(string userId)
        {
            String basketData = await _redisCache.GetStringAsync(userId);
            Basket basket = String.IsNullOrEmpty(basketData) ? new Basket(userId) : JsonConvert.DeserializeObject<Basket>(basketData);
            return basket;
        }
        public async Task<Basket> AddToBasket(Basket basket)
        {
            await _redisCache.SetStringAsync(basket.UserId, JsonConvert.SerializeObject(basket));

            return await GetBasket(basket.UserId);
        }
        public async Task EmptyBasket(string userId)
        {
            await _redisCache.RemoveAsync(userId);
        }
    }

}

