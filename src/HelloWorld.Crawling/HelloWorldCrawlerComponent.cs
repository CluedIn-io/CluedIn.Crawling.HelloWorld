using CluedIn.Core;
using CluedIn.Crawling.HelloWorld.Core;

using ComponentHost;

namespace CluedIn.Crawling.HelloWorld
{
    [Component(HelloWorldConstants.CrawlerComponentName, "Crawlers", ComponentType.Service, Components.Server, Components.ContentExtractors, Isolation = ComponentIsolation.NotIsolated)]
    public class HelloWorldCrawlerComponent : CrawlerComponentBase
    {
        public HelloWorldCrawlerComponent([NotNull] ComponentInfo componentInfo)
            : base(componentInfo)
        {
        }
    }
}

