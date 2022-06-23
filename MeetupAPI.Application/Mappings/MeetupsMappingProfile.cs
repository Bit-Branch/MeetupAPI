using AutoMapper;
using MeetupAPI.Application.Commands.Meetups;
using MeetupAPI.Application.Responses;
using MeetupAPI.Domain.Entities;

namespace MeetupAPI.Application.Mappings
{
    public class MeetupsMappingProfile : Profile
    {
        public MeetupsMappingProfile()
        {
            CreateMap<CreateMeetupCommand, Meetup>();
            CreateMap<UpdateMeetupCommand, Meetup>()
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore());
            CreateMap<Meetup, GetMeetupResponse>();
        }
    }
}
