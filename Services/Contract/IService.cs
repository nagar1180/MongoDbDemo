using Shared.Dtos;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
   public interface IService<T> where T : EntityDto
    {
        Task<T> Save(T obj);
        Task<List<T>> GetAll();
        Task<T> GetById(string id);
        Task<T> Update(string id, T obj);
        Task Delete(string id);
    }
}
