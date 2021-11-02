using AutoMapper;
using EventBus.Events;
using MassTransit;
using MediatR;
using ReservationManager.Application.Commands.ExecuteReservation;
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

        public ReservationExecuteConsumer(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<ReservationExecutedEvent> context)
        {
            var command = _mapper.Map<ExecuteReservationCommand>(context.Message);
            var result = await _mediator.Send(command);
        }

    }
}
