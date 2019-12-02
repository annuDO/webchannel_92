using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Fields;

namespace Trelleborg.Foundation.Indexing.Infrastructure.Fields
{
  public class ArticleYearComputedField : IComputedIndexField
  {
    public string FieldName { get; set; }
    public string ReturnType { get; set; }

    public object ComputeFieldValue(IIndexable indexable)
    {
      var indexItem = indexable as SitecoreIndexableItem;
      if (indexItem == null)
      {
        return null;
      }
      var item = indexItem.Item;
      if (!string.IsNullOrEmpty(item["ArticleDate"]))
      {
        var dateField = (DateField)item.Fields["ArticleDate"];
        var itemDate = Sitecore.DateUtil.IsoDateToDateTime(dateField.Value);
        return itemDate.Year.ToString(System.Globalization.CultureInfo.InvariantCulture);
      }
      return "";
    }
  }
}