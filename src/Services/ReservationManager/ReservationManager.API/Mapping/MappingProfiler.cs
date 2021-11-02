using AutoMapper;
using EventBus.Events;
using ReservationManager.Application.Commands.ExecuteReservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationManager.API.Mapping
{
    public class MappingProfiler: Profile
    {
        public MappingProfiler()
        {
            CreateMap<ExecuteReservationCommand, ReservationExecutedEvent>().ReverseMap()
                .ForMember(dest => dest.ReservedBooks, opt => opt.MapFrom(src => src.Items.Select(it => it.ItemId)));
        }
    }
}
