using System.Collections.Generic;
using Tangent.Core.Domain.Employees;

namespace Tangent.Services.Employees
{
    public interface IEmployeeService
    {
       List<Employee> SearchEmployees(string apiUri = null);
       int GetNumberOfEmployees();
       int GetBirthDays();
       int GetPositions();
    }
}
