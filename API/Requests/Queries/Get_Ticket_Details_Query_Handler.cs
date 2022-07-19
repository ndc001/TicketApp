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
    public class Get_Ticket_Details_Query_Handler : IRequestHandler<Get_Ticket_Details_Query, Ticket_Dto>
    {
       
        private readonly IMapper mapper;
        private IUnit_Of_Work unit_of_work;

        public Get_Ticket_Details_Query_Handler(IMapper mapper, IUnit_Of_Work unit_of_work)
        {
            this.mapper = mapper;
            this.unit_of_work = unit_of_work;
        }

        //Gets the ticket by id and maps it into a Ticket_Dto Response
        public async Task<Ticket_Dto> Handle(Get_Ticket_Details_Query request, CancellationToken cancellationToken)
        {
            var ticket = new Ticket();
            var ticket_dto = new Ticket_Dto();

            ticket = await this.unit_of_work.ticket_repository.Get(request.id);
            ticket_dto = this.mapper.Map<Ticket_Dto>(ticket);

            return ticket_dto;
        }
    }
}