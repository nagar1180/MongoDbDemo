using AutoMapper;
using Shared.Dtos;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Extensions
{
    public static class MapperHelper
    {
        private static IMapper _mapper;
       
        public static void Initialize(IMapper mapper)
        {
            _mapper = mapper;
        }
        public static Employee MapToEmployee(this EmployeeDto emp)
        {
            return _mapper.Map<Employee>(emp);
        }

        public static List<EmployeeDto> MapToEmployee(this List<Employee> emp)
        {
            return _mapper.Map<List<EmployeeDto>>(emp);
        }

        public static EmployeeDto MapToEmployee(this Employee emp)
        {
            return _mapper.Map<EmployeeDto>(emp);
        }

        public static Department MapToDepartment(this DepartmentDto dept)
        {
            return _mapper.Map<Department>(dept);
        }

        public static DepartmentDto MapToDepartment(this Department dept)
        {
            return _mapper.Map<DepartmentDto>(dept);
        }
        public static List<DepartmentDto> MapToDepartment(this List<Department> dept)
        {
            return _mapper.Map<List<DepartmentDto>>(dept);
        }
    }
}
