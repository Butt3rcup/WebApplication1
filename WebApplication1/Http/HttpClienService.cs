using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Http
{
    public class HttpClienService
    {

        private readonly IHttpClientFactory IHttpClientFactory;

        public HttpClienService(IHttpClientFactory httpClientFactory)
        {
            IHttpClientFactory = httpClientFactory;
        }


        public async Task<string> Get(Dictionary<string, string> parameters, string requestUri, string token)
        {
            var Client = IHttpClientFactory.CreateClient();

            //添加请求头
            if (!string.IsNullOrWhiteSpace(token))
            {
                Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);


            }
            Client.DefaultRequestHeaders
               .Accept
               .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header
            //拼接地址
            if (parameters != null)
            {
                var strParam = string.Join("&", parameters.Select(o => o.Key + "=" + o.Value));
                requestUri = string.Concat(requestUri, '?', strParam);
            }
            Client.BaseAddress = new Uri(requestUri);


            string stringAsync = await Client.GetStringAsync(requestUri);

            return stringAsync;
        }



        public void T(string url)
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri(url) };
            client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "relativeAddress")
            {
                Content = new StringContent("{\"name\":\"John Doe\",\"age\":33}",
                    Encoding.UTF8,
                    "application/json")
            };
            //CONTENT-TYPE header

            client.SendAsync(request)
                  .ContinueWith(responseTask =>
                  {
                      Console.WriteLine("Response: {0}", responseTask.Result);
                  });
        }


        public async Task<string> GetContent(string url)
        {
            var Client = IHttpClientFactory.CreateClient();


            string result = await Client.GetStringAsync(url);
            return result;
        }
    }
}
