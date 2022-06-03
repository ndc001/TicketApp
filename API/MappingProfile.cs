using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain;
using API.DTOs.TicketDtos;
using API.DTOs.TicketNoteDtos;
using AutoMapper;

namespace API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Ticket, CreateTicketDto>().ReverseMap(); 
            CreateMap<Ticket, TicketDto>().ReverseMap();
            CreateMap<TicketNote, CreateTicketNoteDto>().ReverseMap();
            CreateMap<TicketNote, TicketNoteDto>().ReverseMap();
                      
        }
    }
}