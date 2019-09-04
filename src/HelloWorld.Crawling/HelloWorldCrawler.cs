using System.Collections.Generic;

using CluedIn.Core.Crawling;
using CluedIn.Crawling.HelloWorld.Core;
using CluedIn.Crawling.HelloWorld.Infrastructure.Factories;

namespace CluedIn.Crawling.HelloWorld
{
    public class HelloWorldCrawler : ICrawlerDataGenerator
    {
        private readonly IHelloWorldClientFactory _clientFactory;
        public HelloWorldCrawler(IHelloWorldClientFactory clientFactory)
        {
            this._clientFactory = clientFactory;
        }

        public IEnumerable<object> GetData(CrawlJobData jobData)
        {
            if (!(jobData is HelloWorldCrawlJobData helloworldcrawlJobData))
            {
                yield break;
            }

            var client = this._clientFactory.CreateNew(helloworldcrawlJobData);

            //crawl data from provider and yield objects

            foreach( var user in client.GetUsers().Result)
            {
                yield return user;
            }
        }       
    }
}
