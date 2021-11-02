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
    public class DepartmentService : IDepartmentService<DepartmentDto>
    {
        private readonly IMapper mapper;
        private readonly IDepartmentRepository departmentRepository;
        public DepartmentService(IMapper mapper, IDepartmentRepository employeeRepository)
        {
            this.mapper = mapper;
            this.departmentRepository = employeeRepository;
        }
        public async Task Delete(string id)
        {
            await departmentRepository.Delete(id);
        }

        public async Task<List<DepartmentDto>> GetAll()
        {
            var outPut = await departmentRepository.GetAll();
            var result = outPut.MapToDepartment();
            return result;
        }

        public async Task<DepartmentDto> GetById(string id)
        {
            var outPut = await departmentRepository.GetById(id);
            var result = outPut.MapToDepartment();
            return result;
        }

        public async Task<DepartmentDto> Save(DepartmentDto obj)
        {
            var dept = obj.MapToDepartment();
            var outPut = await departmentRepository.Add(dept);
            var result = outPut.MapToDepartment();
            return result;
        }

        public async Task<DepartmentDto> Update(string id, DepartmentDto obj)
        {
            var dept = obj.MapToDepartment();
            var outPut = await departmentRepository.Update(id, dept);
            var result = outPut.MapToDepartment();
            return result;
        }
    }
}
