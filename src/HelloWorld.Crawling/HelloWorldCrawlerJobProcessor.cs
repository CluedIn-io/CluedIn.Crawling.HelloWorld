using CluedIn.Crawling.HelloWorld.Core;

namespace CluedIn.Crawling.HelloWorld
{
    public class HelloWorldCrawlerJobProcessor : GenericCrawlerTemplateJobProcessor<HelloWorldCrawlJobData>
    {
        public HelloWorldCrawlerJobProcessor(HelloWorldCrawlerComponent component) : base(component)
        {
        }
    }
}
