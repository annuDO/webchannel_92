using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore;
using Sitecore.Caching.Generics;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using Sitecore.Data.Templates;
using Sitecore.Diagnostics;
using Sitecore.Globalization;
using Sitecore.Links;
using Sitecore.Resources.Media;

namespace Trelleborg.Foundation.SitecoreExtensions
{
    public static class ItemExtensions
    {

    public static IEnumerable<Item> GetMultiListValueItems(this BaseItem item, ID fieldId)
    {
      return new MultilistField(item?.Fields[fieldId]).GetItems();
    }
    public static string Url(this Item item, UrlOptions options = null)
    {
      if (item == null)
        throw new ArgumentNullException(nameof(item));

      if (options != null)
        return LinkManager.GetItemUrl(item, options);
      return !item.Paths.IsMediaItem ? LinkManager.GetItemUrl(item) : MediaManager.GetMediaUrl(item);
    }

    public static string ImageUrl(this Item item, ID imageFieldId, MediaUrlOptions options = null)
    {
      if (item == null)
        throw new ArgumentNullException(nameof(item));

      var imageField = (ImageField)item.Fields[imageFieldId];
      return imageField?.MediaItem == null ? string.Empty : imageField.ImageUrl(options);
    }

    public static string ImageUrl(this MediaItem mediaItem, int width, int height)
    {
      if (mediaItem == null)
        throw new ArgumentNullException(nameof(mediaItem));

      var options = new MediaUrlOptions { Height = height, Width = width };
      var url = MediaManager.GetMediaUrl(mediaItem, options);
      var cleanUrl = Sitecore.StringUtil.EnsurePrefix('/', url);
      var hashedUrl = HashingUtils.ProtectAssetUrl(cleanUrl);

      return hashedUrl;
    }

    public static string LinkFieldUrl(this Item item, ID fieldID)
    {
      if (item == null)
      {
        throw new ArgumentNullException(nameof(item));
      }
      if (ID.IsNullOrEmpty(fieldID))
      {
        throw new ArgumentNullException(nameof(fieldID));
      }
      var field = item.Fields[fieldID];
      if (field == null || !(FieldTypeManager.GetField(field) is LinkField))
      {
        return string.Empty;
      }
      else
      {
        return GetLinkFieldUrl(field);
      }
    }
    public static string GetLinkFieldUrl(Field field)
    {
      LinkField linkField = (LinkField)field;
      string linkType = linkField.LinkType.ToLower(System.Globalization.CultureInfo.InvariantCulture);
      switch (linkType)
      {
        case "internal":
          // Use LinkMananger for internal links, if link is not empty
          return linkField.TargetItem != null ? Sitecore.Links.LinkManager.GetItemUrl(linkField.TargetItem) : string.Empty;
        case "media":
          // Use MediaManager for media links, if link is not empty
          return linkField.TargetItem != null ? Sitecore.Resources.Media.MediaManager.GetMediaUrl(linkField.TargetItem) : string.Empty;
        case "external":
          // Just return external links
          return linkField.Url;
        case "anchor":
          // Prefix anchor link with # if link if not empty
          return !string.IsNullOrEmpty(linkField.Anchor) ? "#" + linkField.Anchor : string.Empty;
        case "mailto":
          // Just return mailto link
          return linkField.Url;
        case "javascript":
          // Just return javascript
          return linkField.Url;
        default:
          // Just please the compiler, this
          // condition will never be met
          return linkField.Url;
      }
    }
    public static Item[] GetAncestorsAndSelf(this Item item)
        {
            var items = new List<Item>(item?.Axes.GetAncestors()) { item };
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
              new global::Sitecore.Publishing.PublishOptions(item?.Database,
                                                     Context.Site.Database,
                                                     global::Sitecore.Publishing.PublishMode.SingleItem,
                                                     item?.Language,
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

    public static string ImageFieldUrl(this Item item, string fieldName)
    {
      if (item == null)
      {
        throw new ArgumentNullException(nameof(item));
      }
      if (string.IsNullOrEmpty(fieldName))
      {
        throw new ArgumentNullException(nameof(fieldName));
      }

      var field = (ImageField)item.Fields[fieldName];
      if (field == null)
      {
        return string.Empty;
      }
      else
      {
        var urlOptions = new MediaUrlOptions();
        if (int.TryParse(field.Height, out var height) && int.TryParse(field.Width, out var width))
        {
          urlOptions.Width = width;
          urlOptions.Height = height;
        }
        return HashingUtils.ProtectAssetUrl(MediaManager.GetMediaUrl(field.MediaItem, urlOptions));
      }
    }

  }
}
