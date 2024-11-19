using GuidExample.Models;
using GuidExample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GuidExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            var employee = _employeeService.GetEmployee(id);
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            if(!ModelState.IsValid)
            {
                var errors = string.Join(";", ModelState.Values
                    .SelectMany(v=>v.Errors)
                    .Select(e=>e.ErrorMessage));
                throw new ValidationException($"{errors}");
            }
            var newEmployee = _employeeService.AddEmployee(employee);
            return Ok(newEmployee);
        }
    }
}