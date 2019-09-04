using System;
using CluedIn.Core;
using CluedIn.Core.Data;
using CluedIn.Crawling.Factories;
using CluedIn.Crawling.Helpers;

using CluedIn.Crawling.HelloWorld.Vocabularies;
using CluedIn.Crawling.HelloWorld.Core.Models;
using RuleConstants = CluedIn.Core.Constants.Validation.Rules;

namespace CluedIn.Crawling.HelloWorld.ClueProducers
{
  public class UserClueProducer : BaseClueProducer<User>
  {
    private readonly IClueFactory _factory;

    public UserClueProducer(IClueFactory factory)
    {
        this._factory = factory ?? throw new ArgumentNullException(nameof(factory));
    }

    protected override Clue MakeClueImpl(User input, Guid accountId)
    {
      if (input == null) throw new ArgumentNullException(nameof(input));

      // TODO: Create clue specifying the type of entity it is and ID
      var clue = this._factory.Create(EntityType.Person, input.id.ToString(), accountId);

      // TODO: Populate clue data
      var data = clue.Data.EntityData;

      var vocab = new UserVocabulary();
      data.Properties[vocab.Id] = input.id.PrintIfAvailable();

      data.Name = input.name.PrintIfAvailable();
      data.Properties[vocab.Name] = input.name.PrintIfAvailable();

      data.Properties[vocab.Email] = input.email;
      data.Properties[vocab.Username] = input.username;

      clue.ValidationRuleSuppressions.AddRange(new[]
      {
          RuleConstants.DATA_001_File_MustBeIndexed,
          RuleConstants.METADATA_002_Uri_MustBeSet,
          RuleConstants.METADATA_003_Author_Name_MustBeSet,
          RuleConstants.PROPERTIES_002_Unknown_VocabularyKey_Used
      });

      return clue;
    }
  }
}
