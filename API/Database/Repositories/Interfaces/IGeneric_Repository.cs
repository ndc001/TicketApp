using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Database.Repositories
{
    public interface IGeneric_Repository<T> where T : class
    {        
        Task<T> Add(T entity);
        Task<bool> Exists(int id);
        Task<T> Get(int id);        
    }
}