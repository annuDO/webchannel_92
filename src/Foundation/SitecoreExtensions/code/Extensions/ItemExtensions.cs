using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore;
using Sitecore.Caching.Generics;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using Sitecore.Data.Templates;
using Sitecore.Diagnostics;
using Sitecore.Globalization;

namespace DLBi.Sitecore.Extensions
{
    public static class ItemExtensions
    {
        public static Item[] GetAncestorsAndSelf(this Item item)
        {
            var items = new List<Item>(item.Axes.GetAncestors()) { item };
            items.Reverse();
            return items.ToArray();
        }

        public static bool IsDerivedFrom(this Item item, ID templateId)
        {
            Assert.ArgumentNotNull(item, "item");

            if (ID.IsNullOrEmpty(templateId))
                return false;

            var templateItem = item.Database.Items[templateId];
            if (templateItem == null)
                return false;

            var template = TemplateManager.GetTemplate(item);

            return template.ID == templateItem.ID || template.DescendsFrom(templateItem.ID);
        }

        public static IEnumerable<Item> GetReferrers(this Item item, Database database = null, Language language = null)
        {
            if (database == null)
                database = Context.Database;

            if (language == null)
                language = Context.Language;

            var links = Globals.LinkDatabase.GetReferrers(item);

            if (links == null) return null;

            var result =
                links.Where(x => x.SourceDatabaseName == database.Name)
                     .Select(x => database.GetItem(x.SourceItemID, language))
                     .Where(dbItem => dbItem != null);

            return result;
        }

        public static void PublishItem(this Item item)
        {
            // The publishOptions determine the source and target database,
            // the publish mode and language, and the publish date
            var publishOptions =
              new global::Sitecore.Publishing.PublishOptions(item.Database,
                                                     Context.Site.Database,
                                                     global::Sitecore.Publishing.PublishMode.SingleItem,
                                                     item.Language,
                                                     DateTime.Now);  // Create a publisher with the publishoptions

            var publisher = new global::Sitecore.Publishing.Publisher(publishOptions);

            // Choose where to publish from
            publisher.Options.RootItem = item;

            // Publish children as well?
            publisher.Options.Deep = true;

            // Do the publish!
            publisher.Publish();
        }

        public static bool HasContextLanguage(this Item item)
        {
            if (item == null || item.Versions == null || item.Versions.Count == 0)
                return false;
            var latestLanguageVersion = item.Versions.GetLatestVersion();
            return (latestLanguageVersion != null) && (latestLanguageVersion.Versions.Count > 0);
        }

    }
}
