using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trelleborg.Foundation.Indexing.Infrastructure.Fields
{
  public class LanguageFullNameComputedField : IComputedIndexField
  {
    public string FieldName { get ; set ; }
    public string ReturnType { get ; set ; }

    public object ComputeFieldValue(IIndexable indexable)
    {
      var indexItem = indexable as SitecoreIndexableItem;
      if (indexItem == null)
      {
        return null;
      }
      var item = indexItem.Item;
      var contextLanguage = item.Language;
      var languageFullName = contextLanguage.CultureInfo.IsNeutralCulture ? contextLanguage.CultureInfo.EnglishName : contextLanguage.CultureInfo.Parent.EnglishName;
      return languageFullName;
    }
  }
}