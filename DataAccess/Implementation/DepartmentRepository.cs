using DataAccess.Contract;
using MongoDB.Driver;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementation
{
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IDatabaseSettings settings) : base("Department", settings)
        {

        }
        public async Task<Department> Add(Department obj)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Department>> GetAll()
        {
            var result = await Task.Run(() => Collections.Find(x => true).ToList());
            return result;
        }

        public async Task<Department> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Department> Update(string id, Department obj)
        {
            throw new NotImplementedException();
        }
    }
}
