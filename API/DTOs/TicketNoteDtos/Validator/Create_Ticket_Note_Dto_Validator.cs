using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Database.Repositories.Interfaces;
using FluentValidation;

namespace API.DTOs.TicketNoteDtos.Validator
{
    public class Create_Ticket_Note_Dto_Validator : AbstractValidator<Create_Ticket_Note_Dto>
    {
        private ITicket_Repository ticket_repository;
        public Create_Ticket_Note_Dto_Validator(ITicket_Repository ticket_repository)
        {
            this.ticket_repository = ticket_repository;

            RuleFor(x => x.note_text).NotEmpty().MaximumLength(500);
            RuleFor(x => x.ticket_id).MustAsync(async(id, token) =>
            {
                var ticket_exists = await this.ticket_repository.Exists(id);
                return ticket_exists;
            })
            .WithMessage("{PropertyName} does not exist.");
        }
    }
}