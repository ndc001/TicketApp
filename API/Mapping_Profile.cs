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
    public class Mapping_Profile : Profile
    {
        public Mapping_Profile()
        {
            CreateMap<Ticket, Create_Ticket_Dto>().ReverseMap(); 
            CreateMap<Ticket, Ticket_Dto>().ReverseMap();
            CreateMap<Ticket_Note, Create_Ticket_Note_Dto>().ReverseMap();
            CreateMap<Ticket_Note, Ticket_Note_Dto>().ReverseMap();
                      
        }
    }
}