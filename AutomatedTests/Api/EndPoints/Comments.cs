using AutomatedTests.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedTests.Api.EndPoints
{
    internal class CommentsEndPoint
    {
        const string Url = "/comments";
        private static Client.Client _client;

        public CommentsEndPoint(Client.Client client)
        {
            _client = client;
        }

        public async Task<string> GetCommentsAsync()
        {
            Task<string> comments = null;
            HttpResponseMessage response = await _client.HttpClient.GetAsync(Url);
            if (response.IsSuccessStatusCode)
            {
                comments = response.Content.ReadAsStringAsync();
            }
            return await comments;
        }

    }
}
