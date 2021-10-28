using BasketManager.API.Entities;
using System.Threading.Tasks;

namespace BasketManager.API.Service
{
    public interface IBasketService
    {
        Task EmptyBasket(string userId);
        Task<Basket> GetBasket(string userId);
        Task<Basket> AddToBasket(Basket basket);
    }
}