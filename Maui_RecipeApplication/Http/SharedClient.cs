using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Mobile.Http
{
    public static class SharedClient
    {

        private static readonly HttpClient _httpClient = ReturnClientForLocalDevlopment();
        private static readonly string _baseUri = "https://www.themealdb.com/api/json/v1/1/";

        private static async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            try
            {
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                return await _httpClient.SendAsync(request);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return default;
            }
        }

        private static async Task<T> SendRequestAsync<T>(HttpRequestMessage request)
        {
            var response = await SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }
            else
            {
                return default(T);
            }
        }

        public static async Task<T> GetAsync<T>(string endpoint)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUri}/{endpoint}");
            return await SendRequestAsync<T>(request);
        }

        private static HttpClient ReturnClientForLocalDevlopment()
        {
            HttpClient client = new HttpClient();
            return client;
        }

    }

}





