using Castle.Windsor;
using CluedIn.Core;
using CluedIn.Core.Providers;
using CluedIn.Crawling.HelloWorld.Infrastructure.Factories;
using Moq;

namespace Provider.HelloWorld.Test.HelloWorldProvider
{
  public abstract class HelloWorldProviderTest
  {
    protected readonly ProviderBase Sut;

    protected Mock<IHelloWorldClientFactory> NameClientFactory;
    protected Mock<IWindsorContainer> Container;

    protected HelloWorldProviderTest()
    {
      Container = new Mock<IWindsorContainer>();
      NameClientFactory = new Mock<IHelloWorldClientFactory>();
      var applicationContext = new ApplicationContext(Container.Object);
      Sut = new CluedIn.Provider.HelloWorld.HelloWorldProvider(applicationContext, NameClientFactory.Object);
    }
  }
}
