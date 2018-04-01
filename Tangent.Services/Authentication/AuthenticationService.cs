using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Tangent.Core.Authentication;
using Tangent.Core.Caching;

namespace Tangent.Services.Authentication
{
    public class AuthenticationService :IAuthenticationService
    {
        private const string API_BASEURI = "http://staging.tangent.tngnt.co";
        private const string USERNAME = "pravin.gordhan";
        private const string PASSWORD = "pravin.gordhan";
        private const string TOKEN_KEY = "Tangent.token.";

        private readonly ICacheManager _cacheManager;

        public AuthenticationService(ICacheManager cacheManager)
        {
            this._cacheManager = cacheManager;
        }
        public SecurityToken GetToken()
        {
            var keyValues = new List<KeyValuePair<string, string>>();
            keyValues.Add(new KeyValuePair<string, string>("username", USERNAME));
            keyValues.Add(new KeyValuePair<string, string>("password", PASSWORD));
            var content = new FormUrlEncodedContent(keyValues);

            return _cacheManager.Get(TOKEN_KEY, () =>
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(API_BASEURI);
                    var response = client.PostAsync("/api-token-auth/", content).Result;
                    return  JsonConvert.DeserializeObject<SecurityToken>(response.Content.ReadAsStringAsync().Result);
                }
        } );
        }
    }
}
