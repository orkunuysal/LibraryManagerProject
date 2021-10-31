using ReservationManager.Domain.Common;
using System;
using System.Collections.Generic;

namespace ReservationManager.Domain.Entities
{
    public class ReservationEntity : EntityBase
    {
        public string UserId { get; set; }
        public string EmailAddress { get; set; }

        public List<string> ReservedBooks { get; set; }
        public DateTime ReservationEndDate { get; set; }

    }
}
