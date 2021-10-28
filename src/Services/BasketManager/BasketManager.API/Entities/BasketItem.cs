using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketManager.API.Entities
{
    public class BasketItem
    {
        public int ItemId { get; set; }
        public int ReserveDays { get; set; }
        public string violationFee { get; set; }

    }
}
