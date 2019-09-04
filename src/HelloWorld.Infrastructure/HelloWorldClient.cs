using System;
using CluedIn.Core.Logging;
using CluedIn.Core.Providers;
using CluedIn.Crawling.HelloWorld.Core;
using CluedIn.Crawling.HelloWorld.Core.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace CluedIn.Crawling.HelloWorld.Infrastructure
{
    public class HelloWorldClient
    {
        private const string BaseUri = "https://jsonplaceholder.typicode.com";

        private readonly ILogger _log; 
        private readonly IRestClient _client;

        public HelloWorldClient(ILogger log, HelloWorldCrawlJobData helloWorldCrawlJobData, IRestClient client) // TODO: pass on any extra dependencies
        {
            if (helloWorldCrawlJobData == null) throw new ArgumentNullException(nameof(helloWorldCrawlJobData));

            this._log = log ?? throw new ArgumentNullException(nameof(log));
            this._client = client ??  throw new ArgumentNullException(nameof(client));

            client.BaseUrl = new Uri(BaseUri);
        }

        public async Task<IList<User>> GetUsers() => await this.GetAsync<IList<User>>("users");

        private async Task<T> GetAsync<T>(string url)
        {
            var request = new RestRequest(url, Method.GET);

            var response = await this._client.ExecuteTaskAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                var diagnosticMessage = $"Request to {this._client.BaseUrl}{url} failed, response {response.ErrorMessage} ({response.StatusCode})";

                this._log.Error(() => diagnosticMessage);

                throw new InvalidOperationException($"Communication to jsonplaceholder unavailable. {diagnosticMessage}");
            }

            var data = JsonConvert.DeserializeObject<T>(response.Content);

            return data;
        }


        public AccountInformation GetAccountInformation()
        {
            return new AccountInformation("", ""); //TODO
        }
    }
}
