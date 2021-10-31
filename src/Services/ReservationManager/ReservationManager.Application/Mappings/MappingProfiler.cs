using AutoMapper;
using ReservationManager.Application.Commands.CancelReservation;
using ReservationManager.Application.Commands.ExecuteReservation;
using ReservationManager.Application.Queries.GetReservations;
using ReservationManager.Domain.Entities;

namespace ReservationManager.Reservation.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ReservationEntity, ReservationsDTO>().ReverseMap();
            CreateMap<ReservationEntity, ExecuteReservationCommand>().ReverseMap();
            CreateMap<ReservationEntity, CancelReservationCommand>().ReverseMap();
        }

    }
}
