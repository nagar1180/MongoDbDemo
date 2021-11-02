using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Contract;
using Shared.Dtos;
using Shared.Models;

namespace MongoDbDemo.Pages
{
    public class IndexModel : PageModelBase
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IEmployeeService<EmployeeDto, Employee> employeeService;

        public IndexModel(ILogger<IndexModel> logger, IEmployeeService<EmployeeDto, Employee> employeeService)
        {
            _logger = logger;
            this.employeeService = employeeService;
            Employees = new List<EmployeeDto>();
        }

        public List<EmployeeDto> Employees { get; set; }
        public async Task<IActionResult> OnGet()
        {
            Employees = await employeeService.GetAll();
            return Page();
        }
    }
}
