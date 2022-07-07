using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Database.Repositories.Interfaces;
using FluentValidation;

namespace API.DTOs.TicketDtos.Validator
{
    public class Create_Ticket_Dto_Validator : AbstractValidator<Create_Ticket_Dto>
    {


        public Create_Ticket_Dto_Validator()
        {
            
        }
    }
}