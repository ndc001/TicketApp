using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Database.Repositories.Interfaces;
using API.Domain;
using API.DTOs.TicketNoteDtos.Validator;
using AutoMapper;
using MediatR;

namespace API.Requests.Commands
{
    public class Create_Ticket_Note_Command_Handler : IRequestHandler<Create_Ticket_Note_Command, Create_Ticket_Note_Command_Response>
    {
        private readonly IUnit_Of_Work unit_of_work;
        private readonly IMapper mapper;

        public Create_Ticket_Note_Command_Handler(IUnit_Of_Work unit_of_work, IMapper mapper)
        {
            this.unit_of_work = unit_of_work;
            this.mapper = mapper;
        }

        public async Task<Create_Ticket_Note_Command_Response> Handle(Create_Ticket_Note_Command command, CancellationToken cancellationToken)
        {
            var response = new Create_Ticket_Note_Command_Response();
            var validator = new Create_Ticket_Note_Dto_Validator(this.unit_of_work.ticket_repository);
            var validationResult = await validator.ValidateAsync(command.ticket_note_dto);

            if(validationResult.IsValid == false)
            {
                response.success = false;
                response.message = "Ticket Note Creation Failed";
                response.errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                
                var ticket_note = new Ticket_Note();

                ticket_note.ticket = await this.unit_of_work.ticket_repository.Get(command.ticket_note_dto.ticket_id);                

                ticket_note.created_date = DateTime.Now;
                ticket_note.is_history_note = command.ticket_note_dto.is_history_note;
                ticket_note.is_internal = command.ticket_note_dto.is_history_note;
                ticket_note.note_text = command.ticket_note_dto.note_text;
                           
            
                await this.unit_of_work.ticket_note_repository.Add(ticket_note);
                await this.unit_of_work.Save();

                response.success = true;
                response.message = "Ticket Created.";
                
                this.mapper.Map(ticket_note, response.ticket_note_response);

            }


            
            return response;
        }
    }
}