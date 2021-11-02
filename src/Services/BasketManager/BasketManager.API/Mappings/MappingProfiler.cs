using AutoMapper;
using BasketManager.API.Entities;
using EventBus.Events;

namespace BasketManager.API.Mappings
{
    public class MappingProfiler : Profile
    {
        public MappingProfiler()
        {
            CreateMap<Basket, ReservationExecutedEvent>().ReverseMap();
            CreateMap<BasketItem, ReservedBooks>().ReverseMap();
        }
    }
}
