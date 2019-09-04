using System;
using System.Collections.Generic;
using CluedIn.Core.Net.Mail;
using CluedIn.Core.Providers;

namespace CluedIn.Crawling.HelloWorld.Core
{
  public class HelloWorldConstants
  {
    //public struct KeyName
    //{
    //  public static readonly string ApiKey = nameof(ApiKey);
    //}

    public const string CodeOrigin = "HelloWorld";
    public const string ProviderRootCodeValue = "HelloWorld";
    public const string CrawlerName = "HelloWorldCrawler";
    public const string CrawlerComponentName = "HelloWorldCrawler";
    public const string CrawlerDescription = "HelloWorld is a ... to be completed ..."; // TODO complete the crawler description
    public const string CrawlerDisplayName = "HelloWorld";  // TODO RJ - this field is never used can it be removed ?
    public const string Uri = "https://jsonplaceholder.typicode.com";
    
    public static readonly Guid ProviderId = Guid.Parse("0d883a78-a404-4b74-bb4a-2f345dde8044");   // TODO: Replace value
    public const string ProviderName = "HelloWorld";         // TODO: Replace value
    public const bool SupportsConfiguration = false;          // TODO: Replace value
    public const bool SupportsWebHooks = false;             // TODO: Replace value
    public const bool SupportsAutomaticWebhookCreation = true;             // TODO: Replace value
    public const bool RequiresAppInstall = false;            // TODO: Replace value
    public const string AppInstallUrl = null;             // TODO: Replace value
    public const string ReAuthEndpoint = null;             // TODO: Replace value
    public const string IconUri = "https://s3-eu-west-1.amazonaws.com/staticcluedin/bitbucket.png"; // TODO: Replace value

    public static readonly ComponentEmailDetails ComponentEmailDetails = new ComponentEmailDetails
    {
      Features = new Dictionary<string, string>
            {
                                       { "Tracking",        "Expenses and Invoices against customers" },
                                       { "Intelligence",    "Aggregate types of invoices and expenses against customers and companies." }
                                   },
      Icon = new Uri(IconUri),
      ProviderName = ProviderName,
      ProviderId = ProviderId,
      Webhooks = SupportsWebHooks
    };

    public static IProviderMetadata CreateProviderMetadata()
    {
      return new ProviderMetadata
      {
        Id = ProviderId,
        ComponentName = CrawlerName,
        Name = ProviderName,
        Type = "Cloud",
        SupportsConfiguration = SupportsConfiguration,
        SupportsWebHooks = SupportsWebHooks,
        SupportsAutomaticWebhookCreation = SupportsAutomaticWebhookCreation,
        RequiresAppInstall = RequiresAppInstall,
        AppInstallUrl = AppInstallUrl,
        ReAuthEndpoint = ReAuthEndpoint,
        ComponentEmailDetails = ComponentEmailDetails
      };
    }
  }
}
