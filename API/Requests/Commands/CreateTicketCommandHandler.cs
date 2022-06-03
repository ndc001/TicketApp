using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Database.Repositories.Interfaces;
using API.Domain;
using API.DTOs.TicketDtos;
using API.DTOs.TicketDtos.Validator;
using AutoMapper;
using MediatR;

namespace API.Requests.Commands
{
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTicketCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateTicketCommand command, CancellationToken cancellationToken)
        {
            var response = new CreateTicketCommandResponse();
            var validator = new CreateTicketDtoValidator(_unitOfWork.TicketTypeRepository);
            var validationResult = await validator.ValidateAsync(command.TicketDto);

            if(validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Failed to Create Ticket.";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var ticket = _mapper.Map<Ticket>(command.TicketDto);
                //var userId = ticket.assigned_to;
                /*if(userId.IsValid){
                    ticket.assigned_date = DateTime.Now;
                }*/
                

                
                //ticket.TicketNotes.Add(createdTicketNote);
                ticket.created_date = DateTime.Now;
                ticket = await _unitOfWork.TicketRepository.CreateTicket(ticket);
                await _unitOfWork.Save();



                response.Success = true;
                response.Message = "Ticket Created.";
                response.Id = ticket.ticket_id;
                response.TicketResponse = _mapper.Map<TicketDto>(ticket);
            }

            return response;
        }
    }
}