using AutoMapper;
using MediatR;
using ReservationManager.Application.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ReservationManager.Application.Queries.GetReservations
{
    public class GetAllReservationsQueryHandler : IRequestHandler<GetAllReservationsQuery, List<ReservationsDTO>>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public GetAllReservationsQueryHandler(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task<List<ReservationsDTO>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
        {
            var reservations = await _reservationRepository.GetAllAsync();
            return _mapper.Map<List<ReservationsDTO>>(reservations);
        }

    }
}
