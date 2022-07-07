using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Database.Repositories
{
    public class Generic_Repository<T> : IGeneric_Repository<T> where T : class
    {
        private readonly Ticket_DbContext dbContext;

        public Generic_Repository(Ticket_DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<T> Add(T entity)
        {
            await this.dbContext.AddAsync(entity);
            return entity;
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await Get(id);
            return entity != null;
        }

        public async Task<T> Get(int id)
        {
            return await this.dbContext.Set<T>().FindAsync(id);
        }

       
    }
}