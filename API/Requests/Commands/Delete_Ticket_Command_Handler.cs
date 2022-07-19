using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Database.Repositories.Interfaces;
using API.DTOs.TicketDtos.Validator;
using AutoMapper;
using MediatR;

namespace API.Requests.Commands
{
    public class Delete_Ticket_Command_Handler
    {
        public class Create_Ticket_Command_Handler : IRequestHandler<Delete_Ticket_Command, Base_Command_Response>
    {
        private readonly IUnit_Of_Work unit_of_work;
        private readonly IMapper mapper;

        public Create_Ticket_Command_Handler(IUnit_Of_Work unit_of_work, IMapper mapper)
        {
            this.unit_of_work = unit_of_work;
            this.mapper = mapper;
        }

        public async Task<Base_Command_Response> Handle(Delete_Ticket_Command command, CancellationToken cancellationToken)
        {
            var response = new Base_Command_Response();
            var validator = new Delete_Ticket_Dto_Validator(this.unit_of_work.ticket_repository);
            var validationResult = await validator.ValidateAsync(command.delete_ticket);

            if(validationResult.IsValid == false)
            {
                response.success = false;
                response.message = "Failed to Delete Ticket.";
                response.errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {   
                var ticket = await this.unit_of_work.ticket_repository.Get(command.delete_ticket.ticket_id);
                ticket.is_active = false;                
                await this.unit_of_work.ticket_repository.Delete_Ticket(ticket);
                await this.unit_of_work.Save();

                response.success = true;
                response.message = "Ticket Deleted.";
                response.id = command.delete_ticket.ticket_id;
                
            }

            return response;
        }
    }
    }
}