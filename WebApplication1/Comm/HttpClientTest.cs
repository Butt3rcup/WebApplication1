using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplication1.Comm
{
    public class HttpClientTest
    {
        private static readonly HttpClient _httpClient;
        private static readonly string BASE_ADDRESS = "https://www.baidu.com";

        static HttpClientTest()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("https://www.baidu.com") };

            //帮HttpClient热身
            _httpClient.SendAsync(new HttpRequestMessage
            {
                Method = new HttpMethod("HEAD"),
                RequestUri = new Uri(BASE_ADDRESS + "/")
            })
                .Result.EnsureSuccessStatusCode();
        }

        public async Task<string> PostAsync()
        {
            _httpClient.DefaultRequestHeaders.Connection.Add("keep-alive");

            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.Proxy = null;
            httpClientHandler.UseProxy = false;
            var httpClient = new HttpClient(httpClientHandler);

            var response = await _httpClient.PostAsync("/", new FormUrlEncodedContent(null));
            _httpClient.Dispose();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
