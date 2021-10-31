using MediatR;
using ReservationManager.Application.Queries.GetReservations;
using System.Collections.Generic;

namespace ReservationManager.Application.Queries
{
    public class GetReservationsQuery : IRequest<List<ReservationsDTO>>
    {
        public GetReservationsQuery(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; }

    }

}
