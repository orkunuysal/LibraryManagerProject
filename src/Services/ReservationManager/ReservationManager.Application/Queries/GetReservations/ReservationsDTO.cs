using System;
using System.Collections.Generic;

namespace ReservationManager.Application.Queries.GetReservations
{
    public class ReservationsDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string EmailAddress { get; set; }

        public List<string> ReservedBooks { get; set; }
        public DateTime ReservationEndDate { get; set; }

    }
}
