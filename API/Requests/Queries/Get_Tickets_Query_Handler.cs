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
        private readonly ITicket_Repository ticket_repository;
        private readonly IMapper mapper;
        public Get_Tickets_Query_Handler(ITicket_Repository ticket_repository, IMapper mapper)
        {
            this.ticket_repository = ticket_repository;
            this.mapper = mapper;

        }
        public async Task<List<Get_Ticket_List_Dto>> Handle(Get_Tickets_Query request, CancellationToken cancellationToken)
        {
            var tickets = new List<Ticket>();
            var tickets_dto = new List<Get_Ticket_List_Dto>();

            tickets = await this.ticket_repository.Get_Tickets();
            tickets_dto = this.mapper.Map<List<Get_Ticket_List_Dto>>(tickets);

            return tickets_dto;
        }
    }
}