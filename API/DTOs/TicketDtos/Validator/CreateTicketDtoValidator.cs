using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Database.Repositories.Interfaces;
using FluentValidation;

namespace API.DTOs.TicketDtos.Validator
{
    public class CreateTicketDtoValidator : AbstractValidator<CreateTicketDto>
    {
        private readonly ITicketTypeRepository _ticketTypeRepository;

        public CreateTicketDtoValidator(ITicketTypeRepository ticketTypeRepository)
        {
            _ticketTypeRepository = ticketTypeRepository;
            Include(new ITicketDtoValidator(_ticketTypeRepository));
        }
    }
}