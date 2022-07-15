using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Database.Repositories.Interfaces;
using FluentValidation;

namespace API.DTOs.TicketDtos.Validator
{
    public class Delete_Ticket_Dto_Validator : AbstractValidator<Delete_Ticket_Dto>
    {
        private ITicket_Repository ticket_repository;
        public Delete_Ticket_Dto_Validator(ITicket_Repository ticket_repository)
        {   
            this.ticket_repository = ticket_repository;
            
            RuleFor(x => x.ticket_id).MustAsync(async(id, token) =>
            {
                var ticket_exists = await this.ticket_repository.Exists(id);
                return ticket_exists;
            })
            .WithMessage("{PropertyName} does not exist.");
            
        }
    }
}