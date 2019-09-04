using System;
using CluedIn.Core;
using CluedIn.Core.Data;
using CluedIn.Crawling.Factories;
using CluedIn.Crawling.HelloWorld.Core;
using RuleConstants = CluedIn.Core.Constants.Validation.Rules;

namespace CluedIn.Crawling.HelloWorld.Factories
{
    public class HelloWorldClueFactory : ClueFactory
    {
        public HelloWorldClueFactory()
            : base(HelloWorldConstants.CodeOrigin, HelloWorldConstants.ProviderRootCodeValue)
        {
        }

        protected override Clue ConfigureProviderRoot([NotNull] Clue clue)
        {
            if (clue == null) throw new ArgumentNullException(nameof(clue));

            var data = clue.Data.EntityData;
            data.Name = HelloWorldConstants.CrawlerName;
            data.Uri = new Uri(HelloWorldConstants.Uri);
            data.Description = HelloWorldConstants.CrawlerDescription;

            clue.ValidationRuleSuppressions.AddRange(new[]
            {
                RuleConstants.METADATA_002_Uri_MustBeSet,
                RuleConstants.PROPERTIES_001_MustExist
             });

            return clue;
        }
    }
}
