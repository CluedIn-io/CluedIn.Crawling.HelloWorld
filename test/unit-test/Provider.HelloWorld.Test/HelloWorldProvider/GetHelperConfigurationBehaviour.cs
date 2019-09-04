using System;
using System.Linq;
using CluedIn.Core.Crawling;
using AutoFixture.Xunit2;
using Should;
using Xunit;
using CluedIn.Crawling.HelloWorld.Core;

namespace Provider.HelloWorld.Test.HelloWorldProvider
{
    public class GetHelperConfigurationBehaviour : HelloWorldProviderTest
    {
        private readonly CrawlJobData _jobData;

        public GetHelperConfigurationBehaviour()
        {
            _jobData = new HelloWorldCrawlJobData();
        }


        [Theory]
        [InlineAutoData]
        public void Returns_ValidDictionary_Instance(Guid organizationId, Guid userId, Guid providerDefinitionId)
        {
            Sut.GetHelperConfiguration(null, _jobData, organizationId, userId, providerDefinitionId)
                .Result
                .ShouldNotBeNull();
        }

    }
}
