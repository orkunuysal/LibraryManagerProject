using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Events
{
    public class ReservationExecutedEvent : IntegrationBaseEvent
    {
        public String UserId { get; set; }
        public int ReserveDays { get; set; }
        public List<ReservedBooks> Items { get; set; }

    }
    public class ReservedBooks
    {
        public string ItemId { get; set; }
        public string violationFee { get; set; }

    }
}
