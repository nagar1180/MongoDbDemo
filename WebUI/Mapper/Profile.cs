using AutoMapper;
using Shared.Dtos;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDbDemo.Mapper
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
            var config = new MapperConfiguration(cfg =>
            {
                //cfg.CreateMap<EntityDto, Entity>()
                //.Include<EmployeeDto, Employee>()
                //.Include<DepartmentDto, Department>().ReverseMap();

                cfg.CreateMap<EmployeeDto, Employee>().AfterMap((src, dest)=> {
                    src.EmpName = dest.EmpName;
                    src.Department = dest.Department;
                }).ReverseMap();
               

                cfg.CreateMap<Department, DepartmentDto>().ReverseMap();
            });

            config.AssertConfigurationIsValid();
        }
    }
}
