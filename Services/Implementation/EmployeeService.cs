using AutoMapper;
using DataAccess.Contract;
using Services.Contract;
using Services.Extensions;
using Shared.Dtos;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class EmployeeService : IEmployeeService<EmployeeDto>
    {
        private readonly IMapper mapper;
        private readonly IEmployeeRepository employeeRepository;
        public EmployeeService(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            this.mapper = mapper;
            this.employeeRepository = employeeRepository;
        }
        public async Task Delete(string id)
        {
            await employeeRepository.Delete(id);
        }

        public async Task<List<EmployeeDto>> GetAll()
        {
            try
            {
                var outPut = await employeeRepository.GetAll();
                var result = outPut.MapToEmployee();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<EmployeeDto> GetById(string id)
        {
            var outPut = await employeeRepository.GetById(id);
            var result = outPut.MapToEmployee();
            return result;
        }

        public async Task<EmployeeDto> Save(EmployeeDto obj)
        {          
            var outPut = await employeeRepository.Add(obj.MapToEmployee());
            var result = outPut.MapToEmployee();
            return result;
        }

        public async Task<EmployeeDto> Update(string id, EmployeeDto obj)
        {
            var outPut = await employeeRepository.Update(id, obj.MapToEmployee());
            var result = outPut.MapToEmployee();
            return result;
        }
    }
}
