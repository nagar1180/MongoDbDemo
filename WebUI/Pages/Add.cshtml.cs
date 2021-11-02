using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Services.Contract;
using Shared.Dtos;
using Shared.Models;

namespace MongoDbDemo.Pages
{
    public class AddModel : PageModel
    {
        private readonly IMapper mapper;
        private readonly ILogger<IndexModel> _logger;
        private readonly IEmployeeService<EmployeeDto, Employee> employeeService;

        public AddModel(IMapper mapper, ILogger<IndexModel> logger, IEmployeeService<EmployeeDto, Employee> employeeService)
        {
            this.mapper = mapper;
            _logger = logger;
            this.employeeService = employeeService;
        }
        public EmployeeDto Employee { get; set; }
        public void OnGet()
        {
        }

        public async Task OnSave(EmployeeDto model)
        {
            if (ModelState.IsValid)
            {
                var employee = mapper.Map<Employee>(model);
                await employeeService.Save(employee);               
            }
        }
    }
}
