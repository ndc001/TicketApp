using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Database.Repositories.Interfaces;
using API.Domain;

namespace API.Database.Repositories
{
    public class TicketResolutionTypeRepository : GenericRepository<TicketResolutionType>, ITicketResolutionTypeRepository
    {
        private readonly TicketDbContext _dbContext;

        public TicketResolutionTypeRepository(TicketDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}