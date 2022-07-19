using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Database.Repositories
{
    public interface IGeneric_Repository<T> where T : class
    {        
        //A guarentee that any repository implementing this will have the following (5) functions
        Task<T> Add(T entity);
        Task<bool> Exists(int id);
        Task<T> Get(int id);        
        Task<List<T>> GetAll();
    }
}