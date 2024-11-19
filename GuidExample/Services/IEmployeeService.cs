using GuidExample.Models;

namespace GuidExample.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployee(Guid id);
        Employee AddEmployee(Employee employee);
    }
}