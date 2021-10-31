using AutoMapper;
using MediatR;
using ReservationManager.Application.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ReservationManager.Application.Queries.GetReservations
{
    public class GetReservationsQueryHandler : IRequestHandler<GetReservationsQuery, List<ReservationsDTO>>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public GetReservationsQueryHandler(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task<List<ReservationsDTO>> Handle(GetReservationsQuery request, CancellationToken cancellationToken)
        {
            var reservations = await _reservationRepository.GetReservationsByUserId(request.UserId);
            return _mapper.Map<List<ReservationsDTO>>(reservations);
        }

    }
}
