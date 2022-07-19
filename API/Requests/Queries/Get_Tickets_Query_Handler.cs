using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Database.Repositories.Interfaces;
using API.Domain;
using API.DTOs.TicketDtos;
using AutoMapper;
using MediatR;

namespace API.Requests.Queries
{
    public class Get_Tickets_Query_Handler : IRequestHandler<Get_Tickets_Query, List<Get_Ticket_List_Dto>>
    {
        private readonly IMapper mapper;
        private readonly IUnit_Of_Work unit_of_work;
        public Get_Tickets_Query_Handler(IMapper mapper, IUnit_Of_Work unit_of_work)
        {
            this.mapper = mapper;
            this.unit_of_work = unit_of_work;

        }
        //Gets all tickets and maps it into a List of Tickets in DTO form
        public async Task<List<Get_Ticket_List_Dto>> Handle(Get_Tickets_Query request, CancellationToken cancellationToken)
        {
            var tickets = new List<Ticket>();
            var tickets_dto = new List<Get_Ticket_List_Dto>();

            tickets = await this.unit_of_work.ticket_repository.GetAll();
            tickets_dto = this.mapper.Map<List<Get_Ticket_List_Dto>>(tickets);

            return tickets_dto;
        }
    }
}