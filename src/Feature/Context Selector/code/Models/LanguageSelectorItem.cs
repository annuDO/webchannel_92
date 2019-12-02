using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trelleborg.Feature.ContextSelector.Models
{
  public class LanguageSelectorItem
  {
   // public Item InnerItem { get; set; }

    public string Href { get; set; }

    public string Name { get; set; }

    public string NativeName { get; set; }

    public string CssClasses { get; set; }
    public string TwoLetterCode { get; set; }

    public string LanguageCode { get; set; }
    //public LanguageSelectorItem(Item item)
    //{
    //  this.InnerItem = item;
    //}
  }
}