using AutoMapper;
using DataAccess.Contract;
using DataAccess.Implementation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Contract;
using Services.Extensions;
using Services.Implementation;
using Shared.Dtos;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Container
{
    public class ContainerService
    {
        public static void Register(IServiceCollection services, IConfiguration configuration, IMapper mapper)
        {
            var connectionString = configuration.GetSection("DatabaseSettings").GetValue<string>("ConnectionString");
            var dataBaseName = configuration.GetSection("DatabaseSettings").GetValue<string>("DatabaseName");
            services.AddSingleton<IDatabaseSettings>(new DatabaseSettings(connectionString, dataBaseName));
            services.AddScoped<IEmployeeService<EmployeeDto>, EmployeeService>();
            services.AddScoped<IDepartmentService<DepartmentDto>, DepartmentService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            MapperHelper.Initialize(mapper);
        }
    }
}
