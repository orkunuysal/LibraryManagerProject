using MediatR;
using ReservationManager.Application.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ReservationManager.Application.Commands.CancelReservation
{
    public class CancelReservationCommandHandler : IRequestHandler<CancelReservationCommand>
    {
        private readonly IReservationRepository _reservationRepository;

        public CancelReservationCommandHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<Unit> Handle(CancelReservationCommand request, CancellationToken cancellationToken)
        {
            var reservationToCancel = await _reservationRepository.GetByIdAsync(request.Id);
            if(reservationToCancel == null)
            {
                throw new Exception();
            }
            await _reservationRepository.DeleteAsync(reservationToCancel);
            return Unit.Value;

        }

    }
}
