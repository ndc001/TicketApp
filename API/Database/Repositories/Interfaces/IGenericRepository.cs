using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Database.Repositories
{
    public interface IGenericRepository<T> where T : class
    {        
        Task<T> Add(T entity);
        Task<bool> Exists(int id);        
    }
}