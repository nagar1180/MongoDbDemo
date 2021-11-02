using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contract;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService<EmployeeDto> employeeService;
        private readonly IDepartmentService<DepartmentDto> departmentService;

        public EmployeeController(IEmployeeService<EmployeeDto> employeeService, IDepartmentService<DepartmentDto> departmentService)
        {
            this.employeeService = employeeService;
            this.departmentService = departmentService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await employeeService.GetAll();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var model = await employeeService.GetById(id);
            var departments = await departmentService.GetAll();
            ViewData["Departments"] = departments.Select(x => new SelectListItem { Value = x.DepartmentName, Text = x.DepartmentName, Selected = x.DepartmentName.Equals(model.DepartmentName) });
           
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, EmployeeDto model)
        {
           
            var departments = await departmentService.GetAll();
            ViewData["Departments"] = departments.Select(x => new SelectListItem { Value = x.DepartmentName, Text = x.DepartmentName, Selected = x.DepartmentName.Equals(model.DepartmentName) });

            var result = await employeeService.Update(id, model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new EmployeeDto();
            var departments = await departmentService.GetAll();
            ViewData["Departments"] = departments.Select(x => new SelectListItem { Value = x.DepartmentName, Text = x.DepartmentName });
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await employeeService.Save(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Detail(string id)
        {
            var model = await employeeService.GetById(id);
            return View(model);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await employeeService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
