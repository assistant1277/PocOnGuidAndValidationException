using GuidExample.Exceptions;
using GuidExample.Models;
using GuidExample.Repositories;

namespace GuidExample.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public List<Employee> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAll().ToList();
            if (!employees.Any())
            {
                throw new EmployeeNotFoundException("No employees found");
            }
            return employees;
        }

        public Employee GetEmployee(Guid id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee == null)
            {
                throw new EmployeeNotFoundException($"Employee with id {id} not found");
            }
            return employee;
        }

        public Employee AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new EmployeeNotFoundException("Employee details cannot be null");
            }
            _employeeRepository.Add(employee);
            return employee;
        }
    }
}