using API.Database.Repositories.Interfaces;
using API.DTOs.TicketDtos;
using FluentValidation;

/*namespace API.DTOs.TicketDtos.Validator
{
    public class ITicket_Dto_Validator : AbstractValidator<ITicket_Dto>
    {
        
       

        public ITicket_Dto_Validator()
        {
            

            RuleFor(t => t.title).NotEmpty().WithMessage("Please set a title.");
            RuleFor(t => t.ticket_description).NotEmpty().WithMessage("Please set a description.");
            RuleFor(t => t.ticket_type).IsInEnum().WithMessage("This {PropertyName} does not exist.");
            
            
        }
    }
}*/