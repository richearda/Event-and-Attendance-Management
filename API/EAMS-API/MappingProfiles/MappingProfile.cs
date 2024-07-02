using AutoMapper;
using ETMS_API.DTOs.Attendee;
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
            CreateMap<UpdateEventCategoryDto, EventCategory>();
            CreateMap<CreateAttendeeDto, Attendee>();
            CreateMap<UpdateAttendeeDto, Attendee>();
            CreateMap<AttendedEventsDto,Attendee>()
                .ForMember(dest => dest.AttendeeId, opt => opt.MapFrom(src => src.AttendeeId))
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.EventId))
                .ForMember(dest => dest.Event.Title, opt => opt.MapFrom(src => src.EventTitle))
                .ForMember(dest => dest.Event.Description, opt => opt.MapFrom(src => src.EventDescription))
                .ForMember(dest => dest.Event.Date, opt => opt.MapFrom(src => src.EventDate))
                .ForMember(dest => dest.Event.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.Event.Organizer, opt => opt.MapFrom(src => src.Organizer))
                .ForMember(dest => dest.CheckInTime, opt => opt.MapFrom(src => src.CheckInTime))
                .ForMember(dest => dest.CheckOutTime, opt => opt.MapFrom(src => src.CheckOutTime)).ReverseMap();
        }
    }
}
