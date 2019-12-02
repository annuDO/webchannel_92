
using Sitecore.Data.Items;
using System.Collections.Generic;
using Trelleborg.Feature.ContextSelector.Models;

namespace Trelleborg.Feature.ContextSelector.Repositories
{

  public interface IMarketSelectorRepository 
  {


     List<RegionItem> GetRegionItems(Item sourceItem);
     LanguageSelectorItem GetActiveLanguageItem { get; }

    }
}
