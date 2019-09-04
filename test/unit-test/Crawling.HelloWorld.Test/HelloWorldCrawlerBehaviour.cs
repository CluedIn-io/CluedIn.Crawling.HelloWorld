using CluedIn.Core.Crawling;
using CluedIn.Crawling;
using CluedIn.Crawling.HelloWorld;
using CluedIn.Crawling.HelloWorld.Infrastructure.Factories;
using Moq;
using Should;
using Xunit;

namespace Crawling.HelloWorld.Test
{
  public class HelloWorldCrawlerBehaviour
  {
    private readonly ICrawlerDataGenerator _sut;

    public HelloWorldCrawlerBehaviour()
    {
        var nameClientFactory = new Mock<IHelloWorldClientFactory>();

        _sut = new HelloWorldCrawler(nameClientFactory.Object);
    }

    [Fact]
    public void GetDataReturnsData()
    {
      var jobData = new CrawlJobData();

      _sut.GetData(jobData)
          .ShouldNotBeNull();
    }
  }
}
