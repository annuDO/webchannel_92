using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Globalization;
using Sitecore.Resources.Media;
using Sitecore.Sites;
using System.Collections.Generic;
using System.Globalization;
using Trelleborg.Feature.ContextSelector.Helper;
using Trelleborg.Feature.ContextSelector.Models;

namespace Trelleborg.Feature.ContextSelector.Repositories
{
  public class SiteSelectorRepository : ISiteSelectorRepository
  {

    public List<SiteSelectorBU> GetSiteSelectorBUItems(Item sourceItem)
    {
      var siteSelectorBUItems = new List<SiteSelectorBU>();
      if (sourceItem != null && sourceItem.Children.Count > 0)
      {
        foreach (Item siteSelectorBUItem in sourceItem.Children)
        {

          var oSiteSelectorBUItem = new SiteSelectorBU();
          oSiteSelectorBUItem.Title = siteSelectorBUItem["Title"];
          oSiteSelectorBUItem.Description = siteSelectorBUItem["Description"];
          oSiteSelectorBUItem.ShortDescription = siteSelectorBUItem["ShortDescription"];
          var oImageItem = new ImageItem();
          Sitecore.Data.Fields.ImageField imageField = siteSelectorBUItem.Fields["DetailImage"];
          if (imageField?.MediaItem != null)
          {
            var image = new MediaItem(imageField.MediaItem);
            oImageItem.Src = StringUtil.EnsurePrefix('/', MediaManager.GetMediaUrl(image));
            oImageItem.Title = image.Title;
            oImageItem.Alt = image.Alt;
          }
          oSiteSelectorBUItem.DetailImage = oImageItem;
          oSiteSelectorBUItem.SiteLink = "#";
          if (!string.IsNullOrEmpty(siteSelectorBUItem["SiteHomePage"]))
          {
            Sitecore.Data.Fields.LinkField siteLinkField = siteSelectorBUItem.Fields["SiteHomePage"];
            switch (siteLinkField.LinkType.ToLower(CultureInfo.CurrentCulture))
            {
              case "internal":
                Language selectedLang = Sitecore.Globalization.Language.Parse("en");
                var siteHomePage = Context.Database.GetItem(siteLinkField.TargetItem.ID, selectedLang);
                if (siteHomePage != null)
                {
                  var siteInfo = LanguageHelper.GetSiteInfo(siteHomePage);
                  var siteContext = Sitecore.Configuration.Factory.GetSite(siteInfo.Name);
                  using (new SiteContextSwitcher(siteContext))
                  {
                    oSiteSelectorBUItem.SiteLink = LanguageHelper.GetSiteItemUrlByLanguage(selectedLang, siteHomePage);
                  }
                  //LanguageHelper.GetSiteItemUrlByLanguage(selectedLang, siteHomePage);
                  
                }
                break;
              case "external":
                oSiteSelectorBUItem.SiteLink = siteLinkField.Url;
                break;
              default:
                oSiteSelectorBUItem.SiteLink = "#";
                break;
            }


          }
          siteSelectorBUItems.Add(oSiteSelectorBUItem);

        }
      }
      return siteSelectorBUItems;


    }
  }
}