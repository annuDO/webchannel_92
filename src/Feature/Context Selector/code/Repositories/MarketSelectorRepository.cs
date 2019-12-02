using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Globalization;
using System.Collections.Generic;
using Trelleborg.Feature.ContextSelector.Helper;
using Trelleborg.Feature.ContextSelector.Models;

namespace Trelleborg.Feature.ContextSelector.Repositories
{
  public class MarketSelectorRepository : IMarketSelectorRepository
  {
    public List<RegionItem> GetRegionItems(Item sourceItem)
    {
      var regionItems = new List<RegionItem>();

      if (sourceItem != null && sourceItem.Children.Count > 0)
      {
        foreach (Item regionItem in sourceItem.Children)
        {
          
            var oRegionItem = new RegionItem();
            oRegionItem.RegionHeading = !string.IsNullOrEmpty(regionItem["Title"]) ? regionItem["Title"]: regionItem.Name ;
            oRegionItem.CountryLinks = new List<CountryItem>();
            if (regionItem.Children.Count > 0)
            {
              foreach (Item countryItem in regionItem.Children)
              {
                
                  CountryItem oCountryItem = new CountryItem();
                  oCountryItem.LinkText = !string.IsNullOrEmpty(countryItem["Title"]) ? countryItem["Title"] : countryItem.Name; 
                  Language selectedLang = Context.Language;
                  if (!string.IsNullOrEmpty(countryItem["Language"]))
                  {
                    Language.TryParse(countryItem["Language"], out selectedLang);
                  }
                  oCountryItem.LinkUrl = LanguageHelper.Create(selectedLang);
                  oRegionItem.CountryLinks.Add(oCountryItem);
                
              }
            }

            regionItems.Add(oRegionItem);
          
        }
      }

      return regionItems;
    }

    public LanguageSelectorItem GetActiveLanguageItem 
    {
      get => LanguageHelper.Create(Context.Language);

    }

  }
}