using System.Net.Http;

namespace Tangent.Services.ResourceClient
{
    public interface IHttpClientService
    {
        HttpResponseMessage GetAsync(string uri);
    }
}
