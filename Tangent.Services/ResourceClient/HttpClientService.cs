using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Tangent.Core.Authentication;
using Tangent.Core.Caching;

namespace Tangent.Services.ResourceClient
{

    public class HttpClientService :IHttpClientService
    {
        private const string API_BASEURI = "http://staging.tangent.tngnt.co";
        private const string USERNAME = "pravin.gordhan";
        private const string PASSWORD = "pravin.gordhan";
        private const string TOKEN_KEY = "Tangent.token.";
        private HttpClient _client;
        private readonly ICacheManager _cacheManager;
        public HttpClientService(ICacheManager cacheManager, HttpClient httpClient)
        {
            this._cacheManager = cacheManager;
            _client = httpClient;
            ConfigurateHttpClient(GetToken());
        }

        public HttpResponseMessage GetAsync(string uri)
        {
            HttpResponseMessage response = _client.GetAsync(uri).Result;
            if (!response.IsSuccessStatusCode)
            {
                var exception = new Exception($"Resource server returned an error. StatusCode : {response.StatusCode}");
                exception.Data.Add("StatusCode", response.StatusCode);
                throw exception;
            }
            return response;
        }

        private void ConfigurateHttpClient(SecurityToken token)//private void ConfigurateHttpClient(HttpClient client, SecurityToken token)
        {
            _client.BaseAddress = new Uri(API_BASEURI);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Add("Authorization", "Token " + token.Token);
        }

        public SecurityToken GetToken()
        {
            var keyValues = new List<KeyValuePair<string, string>>();
            keyValues.Add(new KeyValuePair<string, string>("username", USERNAME));
            keyValues.Add(new KeyValuePair<string, string>("password", PASSWORD));
            var content = new FormUrlEncodedContent(keyValues);

            return _cacheManager.Get(TOKEN_KEY,300, () =>
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(API_BASEURI);
                    HttpResponseMessage response = client.PostAsync("/api-token-auth/", content).Result;
                    return JsonConvert.DeserializeObject<SecurityToken>(response.Content.ReadAsStringAsync().Result);
                }
            });
        }


    }

}
