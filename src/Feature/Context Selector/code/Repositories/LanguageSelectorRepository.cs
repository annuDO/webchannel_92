

using Microsoft.Extensions.DependencyInjection;
using NVelocity.Context;
using Sitecore;
using Sitecore.Abstractions;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.DependencyInjection;
using Sitecore.Globalization;
using Sitecore.Links;
using Sitecore.Sites;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Trelleborg.Feature.ContextSelector.Models;
using Trelleborg.Foundation.DependencyInjection;

namespace Trelleborg.Feature.ContextSelector.Repositories
{
  
  public class LanguageSelectorRepository :  ILanguageSelectorRepository
  {

    public LanguageSelectorRepository()
    {
    }

    private LanguageSelectorItem Create(Language language)
    {
      return new LanguageSelectorItem
      {
        Name = language.CultureInfo.IsNeutralCulture? language.CultureInfo.EnglishName: language.CultureInfo.Parent.EnglishName,
        NativeName = language.CultureInfo.IsNeutralCulture ? language.CultureInfo.NativeName:language.CultureInfo.Parent.NativeName,
        Href =  GetItemUrlByLanguage(language) ,
        TwoLetterCode = language.CultureInfo.TwoLetterISOLanguageName,
        LanguageCode =language.Name
  };
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Minor Code Smell", "S4040:Strings should be normalized to uppercase", Justification = "Url will be in lowercase")]
    private string GetItemUrlByLanguage(Language language)
    {
      using (new LanguageSwitcher(language))
      {
        var options = new UrlOptions
        {
          AlwaysIncludeServerUrl = true,
          LanguageEmbedding = LanguageEmbedding.Always,
          LowercaseUrls = true
        };
        var homePage= Context.Database.GetItem(Context.Site.StartPath);
        var url = LinkManager.GetItemUrl(homePage, options);
        return StringUtil.EnsurePostfix('/', url).ToLowerInvariant();
      }
    }

  

    private IEnumerable<LanguageSelectorItem> GetAll()
    {
     
      var languages = Context.Database.GetLanguages();
      return languages.Select(Create);
    }
    public IEnumerable<LanguageSelectorItem> GetSupportedLanguages()
    {
      var languages = GetAll();
      string languageSelectorSettingPath = string.Format(CultureInfo.InvariantCulture, ConfigurationManager.AppSettings["LanguageSelectorPath"], Sitecore.Context.Site.Name);
      var item = Sitecore.Context.Database.GetItem(languageSelectorSettingPath);

      var supportedLanguagesField = new MultilistField(item.Fields["SupportedLanguages"]);
      if (supportedLanguagesField.Count == 0)
      {
        return Enumerable.Empty<LanguageSelectorItem>();
      }

      var supportedLanguages = supportedLanguagesField.GetItems();

      languages = languages.Where(language => supportedLanguages.Any(lan => lan.Name.Equals(language.LanguageCode,StringComparison.OrdinalIgnoreCase))).OrderBy(lang=>lang.Name);

      return languages;
    }

    public LanguageSelectorItem GetActiveLanguageItem()
    {
      return Create(Context.Language);

    }
  }
}
