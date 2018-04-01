using NUnit.Framework;
using System.Net.Http;
using Tangent.Core.Caching;
using Tangent.Services.ResourceClient;
using Tangent.Tests;

namespace Tangent.Services.Tests
{
    [TestFixture]
    public class HttpClientServiceTests
    {
        private IHttpClientService _httpClientService;
        private ICacheManager _cacheManager;
        private HttpClient _client;

        [SetUp]
        public void SetUp()
        {
            _cacheManager = new TangentNullCache();
            _client = new HttpClient();
            _httpClientService = new HttpClientService(_cacheManager,_client);

        }

        [Test]
        public void Can_Talk_to_the_Service()
        {
            HttpResponseMessage httpResponseMessage = _httpClientService.GetAsync("/api/employee/");
            httpResponseMessage.IsSuccessStatusCode.ShouldBeTrue();
        }

    }
}
