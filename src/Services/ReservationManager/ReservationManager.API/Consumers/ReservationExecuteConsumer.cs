using AutoMapper;
using EventBus.Events;
using MassTransit;
using MediatR;
using ReservationManager.Application.Commands.ExecuteReservation;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationManager.API.Consumers
{
    public class ReservationExecuteConsumer : IConsumer<ReservationExecutedEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ReservationExecuteConsumer(IMediator mediator, IMapper mapper, ILogger logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<ReservationExecutedEvent> context)
        {

            _logger.Information("Reservation Execute command received");
            var command = _mapper.Map<ExecuteReservationCommand>(context.Message);
            var result = await _mediator.Send(command);
        }

    }
}
