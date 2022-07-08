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
        private readonly ITicket_Repository ticket_repository;
        private readonly IMapper mapper;

        public Get_Ticket_Details_Query_Handler(ITicket_Repository ticket_repository, IMapper mapper)
        {
            this.ticket_repository = ticket_repository;
            this.mapper = mapper;
        }
        public async Task<Ticket_Dto> Handle(Get_Ticket_Details_Query request, CancellationToken cancellationToken)
        {
            var ticket = new Ticket();
            var ticket_dto = new Ticket_Dto();

            ticket = await this.ticket_repository.Get_Ticket_Details(request.id);
            ticket_dto = this.mapper.Map<Ticket_Dto>(ticket);

            return ticket_dto;
        }
    }
}