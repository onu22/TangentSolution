using Newtonsoft.Json;
using System.Collections.Generic;
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
        public List<Employee> SearchEmployees(string apiUri="")
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
