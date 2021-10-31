using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationManager.Application.Commands.ExecuteReservation
{
    public class ExecuteReservationCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string EmailAddress { get; set; }

        public List<string> ReservedBooks { get; set; }
        public DateTime ReservationEndDate { get; set; }

    }
}
