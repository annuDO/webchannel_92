using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trelleborg.Feature.ContextSelector.Models
{
  public class LanguageSelectorRenderingModel
  {
    public IList<LanguageSelectorItem> SupportedLanguages { get; set; }

    public LanguageSelectorItem ActiveLanguage { get; set; }
  }
}