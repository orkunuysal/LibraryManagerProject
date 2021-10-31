using AutoMapper;
using MediatR;
using ReservationManager.Application.Contracts;
using ReservationManager.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace ReservationManager.Application.Commands.ExecuteReservation
{
    public class ExecuteReservationCommandHandler : IRequestHandler<ExecuteReservationCommand, int>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public ExecuteReservationCommandHandler(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(ExecuteReservationCommand request, CancellationToken cancellationToken)
        {
            var reservationEntity = _mapper.Map<ReservationEntity>(request);
            var reservation = await _reservationRepository.AddAsync(reservationEntity);

            return reservation.Id;
        }

    }
}
