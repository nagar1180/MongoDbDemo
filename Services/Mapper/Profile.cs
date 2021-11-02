using AutoMapper;
using Shared.Dtos;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDbDemo.Services.Mapper
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Department, DepartmentDto>().ReverseMap();            
        }
    }
}
