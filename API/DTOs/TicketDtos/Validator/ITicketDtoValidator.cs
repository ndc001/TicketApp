using API.Database.Repositories.Interfaces;
using API.DTOs.TicketDtos;
using FluentValidation;

namespace API.DTOs.TicketDtos.Validator
{
    public class ITicketDtoValidator : AbstractValidator<ITicketDto>
    {
        
        private readonly ITicketTypeRepository _ticketTypeRepository;

        public ITicketDtoValidator(ITicketTypeRepository ticketTypeRepository)
        {
            _ticketTypeRepository = ticketTypeRepository;

            RuleFor(t => t.title).NotEmpty().WithMessage("Please set a title.");
            RuleFor(t => t.ticket_description).NotEmpty().WithMessage("Please set a description.");
            RuleFor(t => t.ticket_type).MustAsync(async (type_id, token) => {
                var ticketTypeExists = await _ticketTypeRepository.Exists(type_id);
                return ticketTypeExists;
            }).WithMessage("This {PropertyName} does not exist.");
            
            //Add created_by validation after implementing login/users
            //RuleFor(t => t.created_by)
        }
    }
}