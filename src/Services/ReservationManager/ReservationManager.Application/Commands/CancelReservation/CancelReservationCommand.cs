using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationManager.Application.Commands.CancelReservation
{
    public class CancelReservationCommand : IRequest
    {
        public int Id { get; set; }
    }
}
