using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trelleborg.Feature.ContextSelector.Models
{
  public class MarketSelectorRenderingModel 
  {
   
    public List<RegionItem> RegionItems { get; set; }

    public LanguageSelectorItem ActiveLanguage { get; set; }
  }

  public class RegionItem
  {
    public string RegionHeading { get; set; }
    public List<CountryItem> CountryLinks { get; set; }
  }

  public class CountryItem
  {
    public string LinkText { get; set; }
    public LanguageSelectorItem LinkUrl { get; set; }
  }

  
  }