using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net;
using Newtonsoft.Json;
using System.Text;

namespace AWD.Library
{
    public class ApiClient
    {
        private const string CONTENT_TYPE = "application/json";

        private readonly HttpClient _httpClient;

        private readonly Uri _apiRoot;

        public ApiClient(Uri apiRoot)
        {
            _apiRoot = apiRoot;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(CONTENT_TYPE));
        }

        public async Task<JToken> Get(string query)
        {
            var url = $"{_apiRoot.AbsoluteUri}{query}";
            var result = await _httpClient.GetAsync(url);
            if (result.StatusCode == HttpStatusCode.OK)
                return await result.Content.ReadAsStringAsync();

            return null;
        }

        public async Task<JToken> Post(string url, string content)
        {
            var postUrl = $"{_apiRoot.AbsoluteUri}{url}";

            var result = await _httpClient.PostAsync(postUrl, new StringContent(content, Encoding.UTF8, "application/json"));
            if (result.StatusCode == HttpStatusCode.OK)
                return await result.Content.ReadAsStringAsync();

            result.EnsureSuccessStatusCode();
            return null;
        }
    }
}
