using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using Sitecore.Globalization;
using Sitecore.Links;
using Sitecore.Web.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Trelleborg.Foundation.SitecoreExtensions.Model;

namespace Trelleborg.Foundation.SitecoreExtensions.NVelocity
{
    public class FieldTokens
    {

     
    public  FieldTokens()

    {

    }

    public static string GetLinkUrl(Item item, string fieldName)
        {
            string value = string.Empty;
            if (item != null)
            {
                if (!string.IsNullOrEmpty(fieldName))
                {
                    var field = item.Fields[fieldName];
                    if (field != null)
                    {
                        switch (field.Type)
                        {
                            case "General Link":
                                value = ItemExtensions.LinkFieldUrl(item,field.ID);
                                break;
                            case "Droptree":
                                ReferenceField linkPage = field;
                                value = linkPage.TargetItem.Url();
                                break;
                        }
                    }
                }
                else
                {
                    value = ItemExtensions.Url(item);
                }
            }
            return value;
        }

        public static string GetItemSource(Item item, string fieldName)
        {
            string value = string.Empty;
            if (item != null && !string.IsNullOrEmpty(fieldName))
            {
                    var field = item.Fields[fieldName];
                    value = ItemExtensions.ImageUrl(item, field.ID);
            }
            return value;
        }


    //public static string GetFileIcon(Item item, string fieldName)
    //{
    //    string value = string.Empty;
    //    var field = item.Fields[fieldName];
    //    if (field == null || !(FieldTypeManager.GetField(field) is FileField))
    //    {
    //        return string.Empty;
    //    }
    //    else
    //    {
    //        FileField file = field;
    //        if (file.MediaItem != null)
    //        {
    //            MediaItem mediaItem = new MediaItem(file.MediaItem);
    //            value = Sitecore.Resources.Images.GetThemedImageSource(mediaItem.Icon,
    //                    ImageDimension.id32x32);
    //        }
    //    }
    //    return value;
    //}

    public static string GetDownloadLink(BaseItem item, string fieldName)
        {
            string value = string.Empty;
            var field = item?.Fields[fieldName];
            if (field == null || !(FieldTypeManager.GetField(field) is FileField))
            {
                return string.Empty;
            }
            else
            {
                FileField file = field;
                if (file.MediaItem != null)
                {
                    MediaItem mediaItem = new MediaItem(file.MediaItem);
                    value = Sitecore.Resources.Media.MediaManager.GetMediaUrl(mediaItem);
                }
            }
            return value;
        }

    public static string GetFileSize(BaseItem item, string fieldName)
        {
            string value = string.Empty;
            var field = item?.Fields[fieldName];
            if (field == null || !(FieldTypeManager.GetField(field) is FileField))
            {
                return string.Empty;
            }
            else
            {
                FileField file = field;
                if (file.MediaItem != null)
                {
                    MediaItem mediaItem = new MediaItem(file.MediaItem);
                    var size = (double)mediaItem.Size ;
                    value = StringExtensions.FormatFileSize(size);
                }
            }
            return value;
        }

    public static string GetFileType(BaseItem item, string fieldName)
        {
            string value = string.Empty;
            var field = item?.Fields[fieldName];
            if (field == null || !(FieldTypeManager.GetField(field) is FileField))
            {
                return string.Empty;
            }
            else
            {
                FileField file = field;
                if (file.MediaItem != null)
                {
                    var mediaItem = new MediaItem(file.MediaItem);
                    value = mediaItem.Extension;
                }
            }
            return value;
        }

    public static string GetImageAlt(BaseItem item, string fieldName)
        {
            string value = string.Empty;
            var field = item?.Fields[fieldName];
            if (field == null || !(FieldTypeManager.GetField(field) is ImageField))
            {
                return string.Empty;
            }
            else
            {
                var imageField = (ImageField)field;
                value = imageField.Alt;
            }
            return value;
        }
    public static string GetFieldValue(BaseItem item, string fieldName)
        {
            var field = item?.Fields[fieldName];
            if (field == null)
            {
                return string.Empty;
            }
            else
            {              
                return field.Value;
            }
        }
        //public static string GetItemLocation(Item item)
        //{
        //    var field = GetFieldMultiList(item);
        //    return field.Count().ToString();
        //}
        //private static IEnumerable<Item> GetFieldMultiList([NotNull]Item item)
        //{
        //    var multiListValues = item.GetMultiListValueItems(Templates.SelectorLocations.Fields.Selector);
        //    return multiListValues.Where(i => i.IsDerived(Templates.EventLocation.ID));
        //}
        //public static string DateRelative(Item item, string fieldName, string format)
        //{
        //    var date = DateUtil.IsoDateToDateTime(item[fieldName], DateTime.MinValue);
        //    if (date.Date.Equals(DateTime.UtcNow.Date))
        //    {
        //        return "TODAY";
        //    }
        //    if (date.Date.AddDays(7).Equals(DateTime.UtcNow.Date))
        //    {
        //        return "1 WEEK AGO";
        //    }
        //    var days = (DateTime.UtcNow.Date - date.Date).Days;
        //    if (days > 0 && days < 7)
        //    {
        //        return $"{days} {(days == 1 ? " DAY" : " DAYS")} AGO";
        //    }
        //    return date.ToString(format);
        //}

        //public static string CountGallery(Item item, string fieldName)
        //{
        //    MultilistField field = item.Fields[fieldName];
        //    if (field != null && field.TargetIDs != null)
        //    {
        //        return (field.GetItems().Length > 1) ? field.GetItems().Length.ToString() + " items" : field.GetItems().Length.ToString() + " item";
        //    }
        //    return string.Empty;
        //}
        //public static string MapLocation(Item item, string template, string treelistFieldName, string fieldName)
        //{
        //    string value = string.Empty;
        //    var items = item.Axes.GetDescendants().Where(m => m.TemplateName == template);
        //    if (items != null && items.Any())
        //    {
        //        var results = new List<Item>();
        //        foreach (var refItem in items)
        //        {
        //            ItemLink[] itemLinks = Globals.LinkDatabase.GetReferrers(refItem);
        //            var map = GetRefItem(item, refItem, itemLinks);
        //            MultilistField field = map?.Fields[treelistFieldName];
        //            results.AddRange(field?.TargetIDs?.Select(Context.Database.GetItem));
        //        }
        //        value = results.Count > 1 ? results.Count.ToString()+" location" : results[0]?.Fields[fieldName]?.Value;
        //    }
        //    return value;
        //}
        //private static Item GetRefItem(Item item, Item refItem, ItemLink[] itemLinks)
        //{
        //    if (!itemLinks.Any())
        //        return null;
        //    foreach (ItemLink itemLink in itemLinks)
        //    {
        //        if (itemLink.SourceDatabaseName == item.Database.Name)
        //        {
        //            Item linkItem = Database.GetDatabase(item.Database.Name).Items[itemLink.SourceItemID];
        //            if (linkItem != null && linkItem.ID == item.ID)
        //            {
        //                return refItem;
        //            }
        //        }
        //    }
        //    return null;
        //}

        //public static string GetLinkDescriptionItem(Item item, string fieldName)
        //{
        //    string linkValue = item.Fields[fieldName].Value;
        //    if (linkValue.IndexOf("text=\"") != -1)
        //    {

        //        string titleValue = linkValue.Substring(linkValue.IndexOf("text=\"") + 6);
        //        return titleValue.Substring(0, titleValue.IndexOf("\""));
        //    }
        //    else
        //    {
        //        return item.DisplayName;
        //    }
        //}

        //public static string GetRelatedProducts(Item item, string fieldName)
        //{
        //    string filed = item.Fields[fieldName]?.Value;
        //    if (filed != null)
        //    {
        //        char[] chArray = new char[1] { '|' };
        //        var relateds = new List<Products>();
        //        foreach (string str2 in filed.Split(chArray))
        //        {
        //            if (Sitecore.Data.ID.IsID(str2))
        //            {
        //                Item itemProduct = Sitecore.Context.Database.GetItem(str2);
        //                if (itemProduct != null)
        //                {
        //                    string ImageUrl = string.Empty;
        //                    ImageField imageField = itemProduct.Fields[Templates.RelatedProducts.Fields.Image];
        //                    if (imageField?.MediaItem != null)
        //                    {
        //                        var image = new MediaItem(imageField.MediaItem);
        //                        ImageUrl = StringUtil.EnsurePrefix('/', Sitecore.Resources.Media.MediaManager.GetMediaUrl(image));
        //                    }
        //                    relateds.Add(new Products
        //                    {
        //                        Title = itemProduct.Fields[Templates.RelatedProducts.Fields.Title].Value,
        //                        Description = itemProduct.Fields[Templates.RelatedProducts.Fields.Description].Value,
        //                        Link = GetLinkUrl(itemProduct, Templates.RelatedProducts.Fields.Link.ToString()),
        //                        ImageUrl = ImageUrl,
        //                        TitleLink = GetLinkDescriptionItem(itemProduct, Templates.RelatedProducts.Fields.Link.ToString())
        //                    });
        //                }
        //            }
        //        }
        //        var data = new
        //        {
        //            RelatedProducts = relateds
        //        };
        //        var datas = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize((object)data);
        //        return datas;
        //    }
        //    return null;
        //}

        //public static string GetDataSourceItemId(Item item)
        //{
        //    return item?.ID.Guid.ToString();
        //}

        //public static string GetMapApiName(bool flag)
        //{
        //    return flag ? Constants.ApiMapWithText : Constants.ApiMapFullWidth;
        //}

        //public static string DateStringTense(Item item, string start, string end)
        //{
        //    var dateStart = DateUtil.IsoDateToDateTime(item[start], DateTime.MinValue);
        //    var dateEnd = DateUtil.IsoDateToDateTime(item[end], DateTime.MinValue);
        //    if (dateStart.Date <= DateTime.UtcNow.Date && DateTime.UtcNow.Date <= dateEnd.Date)
        //    {
        //        return "TODAY";
        //    }
        //    if (dateEnd.Date < DateTime.UtcNow.Date)
        //    {
        //        return "PAST";
        //    }
        //    if (dateStart.Date > DateTime.UtcNow.Date)
        //    {
        //        return "UPCOMING";
        //    }
        //    return string.Empty;
        //}

        //public static string DayValue(Item item, string dateField)
        //{
        //    DateTime date = DateUtil.IsoDateToDateTime(item[dateField], DateTime.MinValue);
        //    return date.Day.ToString();
        //}
        //public static string MonthValue(Item item, string dateField)
        //{
        //    DateTime date = DateUtil.IsoDateToDateTime(item[dateField], DateTime.MinValue);
        //    return date.ToString("MMM");
        //}

        //public static string YearValue(Item item, string dateField)
        //{
        //    DateTime date = DateUtil.IsoDateToDateTime(item[dateField], DateTime.MinValue);
        //    return date.Year.ToString();
        //}

        //public static string TimeValue(Item item, string dateField)
        //{
        //    DateTime date = DateUtil.IsoDateToDateTime(item[dateField], DateTime.MinValue);
        //    return date.ToString("h:mm tt");
        //}

        //public static string GetItemIndex(Item item)
        //{
        //    Item _parent = item.Parent;
        //    List<Item> _list = _parent.Children.ToList();
        //    int index = _list.FindIndex(a => a.ID.Equals(item.ID));
        //    index++;
        //    return (index < 10) ? "0" + index.ToString() : index.ToString();
        //}

        //public static string GetCountSlide(Item item)
        //{
        //    Item _parent = item.Parent;
        //    List<Item> _list = _parent.Children.ToList();
        //    int count = _list.Count;
        //    return (count < 10) ? "0" + count.ToString() : count.ToString();
        //}

    //Will return general link fields text
    public static string GetGeneralLinkText(BaseItem item, string fieldName = null)
    {
      string value = string.Empty;
      if (item != null)
      {
        if (!string.IsNullOrEmpty(fieldName))
        {
          var field = item.Fields[fieldName];
          if (field != null && field.Type == "General Link")
          {
            LinkField link = field;
            value = link.Text;
          }
        }
      }
      return value;
    }

    public static string GetShowOnMapLink(BaseItem item, string lat = null, string lon = null)
    {
      if (item == null) return string.Empty;
      //TODO:Integrate Map with china Market
      var mapApi = ConfigurationManager.AppSettings["GoogleMapUrl"];
      return string.Format(System.Globalization.CultureInfo.InvariantCulture,
               mapApi,
               item[lat]?.Replace(',', '.'),
               item[lon]?.Replace(',', '.'),
               Context.Language.CultureInfo.TwoLetterISOLanguageName);

    }

    public static string GetDictionaryValue(string keyPath)
    { if (string.IsNullOrWhiteSpace(keyPath)) return string.Empty;
      var dictionaryFolderPath = Context.Site.RootPath;
      var dictionaryFolderItem = Context.Database.GetItem(dictionaryFolderPath + keyPath);
      if(dictionaryFolderItem==null) //Check in Global Site
      {
        dictionaryFolderItem= Context.Database.GetItem(ConfigurationManager.AppSettings["GlobalDictionaryFolderPath"] + keyPath);
      }
      var value = dictionaryFolderItem!=null? dictionaryFolderItem["Value"]: keyPath.Substring(keyPath.LastIndexOf('/'));
      return  value;

    }

    public static string GetStaticMapLink(BaseItem item, string lat = null, string lon = null)
    {
      if (item == null) return string.Empty;
      //TODO:Integrate Map with china Market
      var mapApi = ConfigurationManager.AppSettings["GoogleStaticMapUrl"];
      return String.Format(System.Globalization.CultureInfo.InvariantCulture,
               mapApi,
               item[lat]?.Replace(',', '.'),
               item[lon]?.Replace(',', '.'));

    }

    public static string GetTranslation(string key)
    {
      return Translate.Text(key);
    }

    /// <summary>
    /// Get list of language version created for item
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public static List<LanguageItem> GetAllLanguageVersions(Item item, bool checkContext =false)
    {
      var languageList = new List<LanguageItem>();
      if (item!=null && item.IsFallback)
      {
        using (new LanguageSwitcher(item.OriginalLanguage))
        {
          item = item.Database.GetItem(item.ID);
        }
      }
      foreach (var itemLanguage in ItemManager.GetContentLanguages(item))
      {
       
        if (ItemManager.GetVersions(item, itemLanguage).Count > 0)
        {
          if (!(checkContext && Context.Language== itemLanguage))
            languageList.Add( CreateLanguage(item,itemLanguage));
        }
      }
      return languageList.OrderBy(x=>x.Name).ToList();
    }

    private static LanguageItem CreateLanguage(Item item, Language language)
    {
      return new LanguageItem
      {
        Name = language.CultureInfo.IsNeutralCulture ? language.CultureInfo.EnglishName : language.CultureInfo.Parent.EnglishName,
        NativeName = language.CultureInfo.IsNeutralCulture ? language.CultureInfo.NativeName : language.CultureInfo.Parent.NativeName,
        Href = GetItemLinkByLanguage(item,language)
      };
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S4040:Strings should be normalized to uppercase", Justification = "<url string should be in lowercase>")]
    private static string GetItemLinkByLanguage(Item item, Language language)
    {
      using (new LanguageSwitcher(language))
      {
        var options = new UrlOptions
        {
          AlwaysIncludeServerUrl = true,
          LanguageEmbedding = LanguageEmbedding.Always,
          LowercaseUrls = true
        };
       // var homePage = Context.Database.GetItem(Context.Site.StartPath);
        var url = LinkManager.GetItemUrl(item, options);
        return StringUtil.EnsurePostfix('/', url).ToLowerInvariant();
      }
    }

    public static string GetContextLangFullName(Item item)
    {
      var language = Context.Language;
      return language.CultureInfo.IsNeutralCulture? language.CultureInfo.EnglishName : language.CultureInfo.Parent.EnglishName;
    }

    public static string GetItemLink(Item item)
    {
      var options = UrlOptions.DefaultOptions;
      return LinkManager.GetItemUrl(item, options);
    }

    public static bool CheckProductIcon(Item item)
    {
      if(item!=null)
      {
        MultilistField selectedIcons = Context.Item.Fields["Icons"];
        if(selectedIcons!=null )
        {
          foreach(var icon in selectedIcons.GetItems())
          {
            if (icon.ID == item.ID) return true;
          }
        }
      }
      return false;
    }
  }
}