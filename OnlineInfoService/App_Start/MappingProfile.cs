using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using OnlineInfoService.Dtos;
using OnlineInfoService.Models;

namespace OnlineInfoService
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Member, MemberDto>();
            Mapper.CreateMap<Event, EventDto>();
            Mapper.CreateMap<Subject, SubjectDto>();
            Mapper.CreateMap<Report, ReportDto>();

            Mapper.CreateMap<MemberDto, Member>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<EventDto, Event>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<ReportDto, Report>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
        

    }
}