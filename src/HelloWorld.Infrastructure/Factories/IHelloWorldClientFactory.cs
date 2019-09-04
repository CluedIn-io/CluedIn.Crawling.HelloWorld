using CluedIn.Crawling.HelloWorld.Core;

namespace CluedIn.Crawling.HelloWorld.Infrastructure.Factories
{
    public interface IHelloWorldClientFactory
    {
        HelloWorldClient CreateNew(HelloWorldCrawlJobData helloworldCrawlJobData);
    }
}
