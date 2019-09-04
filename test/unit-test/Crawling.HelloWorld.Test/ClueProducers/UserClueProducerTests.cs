using System;
using AutoFixture.Xunit2;
using CluedIn.Core.Data;
using CluedIn.Crawling;
using CluedIn.Crawling.HelloWorld.ClueProducers;
using CluedIn.Crawling.HelloWorld.Core.Models;
using Xunit;

namespace Crawling.HelloWorld.Test.ClueProducers
{
    public class UserClueProducerTests : BaseClueProducerTest<User>
    {
        protected override BaseClueProducer<User> Sut =>
            new UserClueProducer(this._clueFactory.Object);

        protected override EntityType ExpectedEntityType => EntityType.Files.File;

        [Theory]
        [InlineAutoData]
        public void ClueHasEdgeToFolder(User samplefile)
        {
            var clue = this.Sut.MakeClue(samplefile, Guid.NewGuid());
            
            Assert.NotNull(clue);

        }
    }
}
