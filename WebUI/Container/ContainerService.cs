using DataAccess.Contract;
using DataAccess.Implementation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Services.Contract;
using Services.Implementation;
using Shared.Dtos;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDbDemo.Container
{
    public class ContainerService
    {
       public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("DatabaseSettings").GetValue<string>("ConnectionString");
            var dataBaseName = configuration.GetSection("DatabaseSettings").GetValue<string>("DatabaseName");           
            services.AddSingleton<IDatabaseSettings>(new DatabaseSettings(connectionString, dataBaseName));
            services.AddScoped<IEmployeeService<EmployeeDto, Employee>, EmployeeService>();
            services.AddScoped<IDepartmentService<DepartmentDto, Department>, DepartmentService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();           
        }

        private static IDatabaseSettings Options(IServiceProvider provider)
        {
           var section = provider.GetRequiredService<IOptions<DatabaseSettings>>().Value;
            var settings = new DatabaseSettings(section.ConnectionString, section.DatabaseName);
            return settings;
        } 
    }
}
