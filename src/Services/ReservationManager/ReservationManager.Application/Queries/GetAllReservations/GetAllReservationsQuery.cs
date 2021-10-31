using MediatR;
using ReservationManager.Application.Queries.GetReservations;
using System.Collections.Generic;

namespace ReservationManager.Application.Queries
{
    public class GetAllReservationsQuery : IRequest<List<ReservationsDTO>>
    {
        public GetAllReservationsQuery()
        {
        }

    }

}
