using Xunit;
using System.Linq;
using CrawlerIntegrationTesting.Clues;
using Xunit.Abstractions;

namespace Tests.Integration.HelloWorld
{
    public class DataIngestion : IClassFixture<HelloWorldTestFixture>
    {
        private const string AtLeastOnPropertyMustExist =
            "CluedIn.Core.Data.Validation.ClueValidationException Clue validation rule PROPERTIES_001_MustExist failed: At least one property must exist";

        private readonly HelloWorldTestFixture _fixture;
        private readonly ITestOutputHelper _output;

        public DataIngestion(HelloWorldTestFixture fixture, ITestOutputHelper output)
        {
            this._fixture = fixture;
            this._output = output;
            
        }

        [Theory]
        [InlineData("/Provider/Root", 1)] 
        [InlineData("/Person", 10)]
        public void CorrectNumberOfEntityTypes(string entityType, int expectedCount)
        {
            var foundCount = this._fixture.ClueStorage.CountOfType(entityType);
            Assert.Equal(expectedCount, foundCount);
        }

        [Fact]
        public void EntityCodesAreUnique()
        {            
            var count = this._fixture.ClueStorage.Clues.Count();
            var unique = this._fixture.ClueStorage.Clues.Distinct(new ClueComparer()).Count();

            //You could use this method to output info of all clues
            this.PrintClues();

            Assert.Equal(unique, count);
        }

        private void PrintClues()
        {
            foreach(var clue in this._fixture.ClueStorage.Clues)
            {
                this._output.WriteLine(clue.OriginEntityCode.ToString());
            }
        }
    }
}
