
using Sitecore.Data.Items;
using System.Collections.Generic;
using Trelleborg.Feature.ContextSelector.Models;

namespace Trelleborg.Feature.ContextSelector.Repositories
{

  public interface ILanguageSelectorRepository 
  {
    IEnumerable<LanguageSelectorItem> GetSupportedLanguages();

  

    LanguageSelectorItem GetActiveLanguageItem();

   



  }
}
