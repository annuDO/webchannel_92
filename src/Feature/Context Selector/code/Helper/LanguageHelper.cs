using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Globalization;
using Sitecore.Links;
using Sitecore.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trelleborg.Feature.ContextSelector.Models;

namespace Trelleborg.Feature.ContextSelector.Helper
{
  public static class LanguageHelper
  {
    public static LanguageSelectorItem Create(Language language)
    {
      if (language == null) return null;
      return new LanguageSelectorItem
      {
        Name = language.CultureInfo.IsNeutralCulture ? language.CultureInfo.EnglishName : language.CultureInfo.Parent.EnglishName,
        NativeName = language.CultureInfo.IsNeutralCulture ? language.CultureInfo.NativeName : language.CultureInfo.Parent.NativeName,
        Href = GetItemUrlByLanguage(language),
        TwoLetterCode = language.CultureInfo.TwoLetterISOLanguageName,
        LanguageCode = language.Name
      };
    }

    public static string GetItemUrlByLanguage(Language language)
    {
      using (new LanguageSwitcher(language))
      {
        var options = new UrlOptions
        {
          AlwaysIncludeServerUrl = true,
          LanguageEmbedding = LanguageEmbedding.Always,
          LowercaseUrls = true
        };
        var homePage = Context.Database.GetItem(Context.Site.StartPath);
        var url = LinkManager.GetItemUrl(homePage, options);
        return StringUtil.EnsurePostfix('/', url).ToLowerInvariant();
      }
    }

    public static string GetSiteItemUrlByLanguage(Language language, Item homeItem)
    {
      using (new LanguageSwitcher(language))
      {
        var options = new UrlOptions
        {
          AlwaysIncludeServerUrl = true,
          LanguageEmbedding = LanguageEmbedding.Always,
          LowercaseUrls = true
        };
        
        var url = LinkManager.GetItemUrl(homeItem, options);
        return StringUtil.EnsurePostfix('/', url).ToLowerInvariant();
      }
    }

    public static SiteInfo GetSiteInfo(this Item item)
    {
      return Sitecore.Links.LinkManager.ResolveTargetSite(item);
    }

  }
}