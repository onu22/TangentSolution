using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Tangent.Core.Caching;
using Tangent.Core.Domain.Employees;
using Tangent.Services.ResourceClient;

namespace Tangent.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IHttpClientService _httpClientService;
        private readonly ICacheManager _cacheManager;

        public EmployeeService(IHttpClientService httpClientService, ICacheManager cacheManager)
        {
            this._cacheManager = cacheManager;
            _httpClientService = httpClientService;
        }

        public int GetBirthDays()
        {
            List<Employee> employees = SearchEmployees();
            var query = from q in employees where q.days_to_birthday == "0" select q;
            return query.Count();
        }

        public int GetNumberOfEmployees()
        {
            List<Employee> employees = SearchEmployees();
            return employees.Count();
        }

        public int GetPositions()
        {
            List<int> positions = new List<int>();
            List<Employee> employees = SearchEmployees();
            foreach (Employee employee in employees)
            {
                if (!positions.Contains(employee.Position.id))
                    positions.Add(employee.Position.id);
            }
            return positions.Count();
        }

        public List<Employee> SearchEmployees(string apiUri= null)
        {
            if (string.IsNullOrEmpty(apiUri))
            {
                apiUri = "/api/employee/";
            }
            string key = $"Tangent.employees.filter-{apiUri}";

            return _cacheManager.Get(key, () =>
            {
                HttpResponseMessage httpResponseMessage = _httpClientService.GetAsync(apiUri);
                Task<string> response = httpResponseMessage.Content.ReadAsStringAsync();
                List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(response.Result);
                return employees;
            });

        }
    }
}
