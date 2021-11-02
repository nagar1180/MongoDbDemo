using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contract
{
   public interface IMongoRepository<T>  where T : Entity
    {
        Task<T> Add(T obj);
        Task<T> Update(string id, T obj);
        Task<List<T>> GetAll();
        Task<T> GetById(string id);
        Task Delete(string id);
    }
}
