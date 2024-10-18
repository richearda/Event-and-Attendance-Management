

using AutoMapper;
using Eams.Core.Domain;
using Eams.Core.DTOs.Attendee;
using Eams.Core.DTOs.Event;
using Eams.Core.DTOs.EventCategory;

namespace Eams.Core.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Event Mapping
            CreateMap<CreateEventDto, Event>();
            CreateMap<UpdateEventDto, Event>().ReverseMap();
            CreateMap<EventDto, Event>()
                .ForMember(dest => dest.Attendees, opt => opt.MapFrom(src => src.Attendees));
            //Event Category Mapping
            CreateMap<CreateEventCategoryDto, EventCategory>().ReverseMap();
            CreateMap<CreateEventCategoryMappingDto, EventCategoryMapping>().ReverseMap();
            CreateMap<UpdateEventCategoryMappingDto, EventCategoryMapping>().ReverseMap();
            CreateMap<UpdateEventCategoryDto, EventCategory>();

            //Attendee Mapping
            CreateMap<CreateAttendeeDto, Attendee>().ReverseMap();
            CreateMap<UpdateAttendeeDto, Attendee>().ReverseMap();
            CreateMap<AttendedEventsDto, Attendee>()
                .ForMember(dest => dest.AttendeeId, opt => opt.MapFrom(src => src.AttendeeId))
                .ForMember(dest => dest.EventId, opt => opt.MapFrom(src => src.EventId))
                .ForPath(dest => dest.Event.Title, opt => opt.MapFrom(src => src.EventTitle))
                .ForPath(dest => dest.Event.Description, opt => opt.MapFrom(src => src.EventDescription))
                .ForPath(dest => dest.Event.Date, opt => opt.MapFrom(src => src.EventDate))
                .ForPath(dest => dest.Event.Location, opt => opt.MapFrom(src => src.Location))
                .ForPath(dest => dest.Event.Organizer, opt => opt.MapFrom(src => src.Organizer))
                .ForMember(dest => dest.CheckInTime, opt => opt.MapFrom(src => src.CheckInTime))
                .ForMember(dest => dest.CheckOutTime, opt => opt.MapFrom(src => src.CheckOutTime))
                .ReverseMap();
            CreateMap<AttendeeDto, Attendee>()
                .ForPath(dest => dest.User.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForPath(dest => dest.User.Address, opt => opt.MapFrom(src => src.Address))
                .ReverseMap();

        }
    }
}
