using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain;

namespace API.Database.Repositories.Interfaces
{
    public interface ITicket_Repository : IGeneric_Repository<Ticket>
    {
        //Guarentees that our ticket repository will be able to delete tickets
        Task Delete_Ticket(Ticket ticket);
    }
}