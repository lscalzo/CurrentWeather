using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CurrentWeather.Helpers
{
    public class HttpRequestSender
    {
        private HttpClient httpClient;

        public HttpRequestSender()
        {
            httpClient = new HttpClient();
        }

        public async Task<string> Get(string URL)
        {
            var response = await httpClient.GetAsync(URL);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<T> GetAs<T>(string URL)
        {
            var response = await Get(URL);
            return JsonConvert.DeserializeObject<T>(response); ;
        }
    }
}
