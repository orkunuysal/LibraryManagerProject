using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketManager.API.Entities
{
    public class Basket
    {
        public Basket()
        {

        }

        public Basket(string userId)
        {
            UserId = userId;
        }

        public String UserId { get; set; }
        public List<BasketItem> Items { get; set; }
    }
}
