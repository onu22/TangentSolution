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
    public class EmployeeReviewService: IEmployeeReviewService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly ICacheManager _cacheManager;
        public EmployeeReviewService(IHttpClientService httpClientService, ICacheManager cacheManager)
        {
            this._cacheManager = cacheManager;
            _httpClientService = httpClientService;
        }
        public int GetReviews()
        {

            string apiUri = "/api/review/";
            string key = $"Tangent.reviews.all-{apiUri}";
            return _cacheManager.Get(key, () =>
            {
                HttpResponseMessage httpResponseMessage = _httpClientService.GetAsync(apiUri);
                Task<string> response = httpResponseMessage.Content.ReadAsStringAsync();
                List<Review> reviews = JsonConvert.DeserializeObject<List<Review>>(response.Result);
                return reviews.Count();
            });
        }
    }
}
