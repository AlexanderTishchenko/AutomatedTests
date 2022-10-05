using System.Net.Http.Headers;
using System.Security.Policy;

namespace AutomatedTests.Api.Client
{
    internal class Client
    {
        public readonly HttpClient HttpClient;
        public Client()
        {
            HttpClient = new HttpClient();

            HttpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}
