using CluedIn.Core.Data;
using CluedIn.Core.Data.Vocabularies;

namespace CluedIn.Crawling.HelloWorld.Vocabularies
{
    public class UserVocabulary : SimpleVocabulary
    {
        public UserVocabulary()
        {
            this.VocabularyName = "HelloWorld User";
            this.KeyPrefix = "helloworld.user";
            this.KeySeparator = ".";
            this.Grouping = EntityType.Unknown;

            this.AddGroup("HelloWorld Details", group =>
              {
                  this.Id = group.Add(new VocabularyKey("Id", VocabularyKeyDataType.Integer, VocabularyKeyVisibility.Visible));
                  this.Name = group.Add(new VocabularyKey("Name", VocabularyKeyDataType.PersonName, VocabularyKeyVisibility.Visible));
                  this.Username = group.Add(new VocabularyKey("Username", VocabularyKeyDataType.PersonName, VocabularyKeyVisibility.Visible));
                  this.Email = group.Add(new VocabularyKey("Email", VocabularyKeyDataType.Email, VocabularyKeyVisibility.Hidden));
              });

        }

        public VocabularyKey Id { get; private set; }
        public VocabularyKey Name { get; private set; }
        public VocabularyKey Username { get; private set; }
        public VocabularyKey Email { get; private set; }
    }
}
