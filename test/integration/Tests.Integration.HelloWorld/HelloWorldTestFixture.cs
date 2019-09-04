using CluedIn.Crawling;
using CluedIn.Crawling.HelloWorld.Core;
using System.IO;
using System.Reflection;
using CrawlerIntegrationTesting.Clues;

namespace Tests.Integration.HelloWorld
{
    public class HelloWorldTestFixture
    {
        public HelloWorldTestFixture()
        {
            var executingFolder = new FileInfo(Assembly.GetExecutingAssembly().CodeBase.Substring(8)).DirectoryName;
            var p = new DebugCrawlerHost<HelloWorldCrawlJobData>(executingFolder, HelloWorldConstants.ProviderName);

            ClueStorage = new ClueStorage();

            p.ProcessClue += ClueStorage.AddClue;            

            p.Execute(HelloWorldConfiguration.Create(), HelloWorldConstants.ProviderId);
        }

        public ClueStorage ClueStorage { get; }

        public void Dispose()
        {
        }

    }
}


