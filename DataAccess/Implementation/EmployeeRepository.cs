using DataAccess.Contract;
using MongoDB.Bson;
using MongoDB.Driver;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementation
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDatabaseSettings settings) : base("Employee", settings)
        {           
        }
        public async Task<Employee> Add(Employee obj)
        {
            await Collections.InsertOneAsync(obj);
            return obj;
        }

        public async Task Delete(string id)
        {
            var filter = Builders<Employee>.Filter.Eq("_id", id.ToObjectId());
            await Collections.DeleteOneAsync(filter);
        }

        public async Task<List<Employee>> GetAll()
        {
            try
            {
                var result = await Task.Run(() => Collections.Find(x => true).ToList());
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Employee> GetById(string id)
        {
           
            var result = await Task.Run(() => Collections.Find(x => x.Id == id.ToObjectId()).FirstOrDefault());            
            return result;
        }

        public async Task<Employee> Update(string id, Employee obj)
        {      
            
            var filter = Builders<Employee>.Filter.Eq("_id", id.ToObjectId());
            var update = Builders<Employee>.Update.Set("EmployeeName", obj.EmployeeName)
                                     .Set("DepartmentName", obj.DepartmentName);          
            await Collections.UpdateOneAsync(filter, update);
            return obj;
        }
    }
}
