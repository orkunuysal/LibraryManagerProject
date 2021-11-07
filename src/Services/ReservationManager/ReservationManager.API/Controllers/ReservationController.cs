using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationManager.Application.Commands.CancelReservation;
using ReservationManager.Application.Commands.ExecuteReservation;
using ReservationManager.Application.Queries;
using ReservationManager.Application.Queries.GetReservations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ReservationManager.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("[action]/{userId}", Name = "GetReservationsByUserId")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ReservationsDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ReservationsDTO>>> GetReservationsByUserId(string userId)
        {
            var query = new GetReservationsQuery(userId);
            var reservations = await _mediator.Send(query);
            return Ok(reservations);
        }

        [HttpGet(Name ="GetReservations")]
        [ProducesResponseType(typeof(IEnumerable<ReservationsDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ReservationsDTO>>> GetReservations()
        {
            var query = new GetAllReservationsQuery();
            var reservations = await _mediator.Send(query);
            return Ok(reservations);
        }

        [HttpPost(Name = "ExecuteReservation")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> ExecuteReservation([FromBody] ExecuteReservationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}", Name = "CancelReservation")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> CancelReservation(int id)
        {
            var command = new CancelReservationCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }



    }
}
