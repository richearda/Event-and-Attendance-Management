using AutoMapper;
using ETMS_API.DTOs.Event;
using ETMS_API.DTOs.EventCategory;
using ETMS_API.Models;

namespace ETMS_API.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateEventDto, Event>();
            CreateMap<CreateEventCategoryDto, EventCategory>();
            CreateMap<CreateEventCategoryMappingDto, EventCategoryMapping>();
            CreateMap<UpdateEventDto, Event>().ReverseMap();
            CreateMap<UpdateEventCategoryMappingDto, EventCategoryMapping>().ReverseMap();
        }
    }
}
