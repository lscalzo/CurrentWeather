using System;
using System.Net.Http;
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
            return await response.Content.ReadAsStringAsync();
        }


    }
}
