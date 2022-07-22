using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Database.Repositories.Interfaces;
using API.Domain;
using API.DTOs.TicketDtos;
using API.DTOs.TicketDtos.Validator;
using API.DTOs.TicketNoteDtos;
using AutoMapper;
using MediatR;

namespace API.Requests.Commands
{
    public class Create_Ticket_Command_Handler : IRequestHandler<Create_Ticket_Command, Create_Ticket_Command_Response>
    {
        private readonly IUnit_Of_Work unit_of_work;
        private readonly IMapper mapper;

        public Create_Ticket_Command_Handler(IUnit_Of_Work unit_of_work, IMapper mapper)
        {
            this.unit_of_work = unit_of_work;
            this.mapper = mapper;
        }

        //Ticket information passed in from controller via command
        //Create_Ticket_Dto_Validator is run
        //If fails validation a list of errors is returned in the response
        //If validation succeeds, maps command into a ticket variable
        //Sets a couple default values
        //Creates a history ticket_note
        //Saves and sends the ticket back in response
        public async Task<Create_Ticket_Command_Response> Handle(Create_Ticket_Command command, CancellationToken cancellationToken)
        {
            var response = new Create_Ticket_Command_Response();
            var validator = new Create_Ticket_Dto_Validator();
            var validationResult = await validator.ValidateAsync(command.ticket_dto);

            if(validationResult.IsValid == false)
            {
                response.success = false;
                response.message = "Failed to Create Ticket.";
                response.errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var ticket = this.mapper.Map<Ticket>(command.ticket_dto);               

                ticket.is_active = true;
                ticket.created_date = DateTime.Now;
                                
                ticket = await this.unit_of_work.ticket_repository.Add(ticket);
                
                var note = new Ticket_Note()
                {
                    created_date = DateTime.Now,
                    is_history_note = true,
                    is_internal = false,
                    note_text = "Ticket Created.",

                };

                
                await this.unit_of_work.Save();

                response.success = true;
                response.message = "Ticket Created.";
                response.id = ticket.ticket_id;
                response.ticket_response = this.mapper.Map<Ticket_Dto>(ticket);
                response.note_response = this.mapper.Map<Create_Ticket_Note_Dto>(note);
            }

            return response;
        }
    }
}