using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace Trelleborg.Foundation.SitecoreExtensions
{
  public class RenderSection : Sitecore.XA.Foundation.RenderingVariants.Pipelines.RenderVariantField.RenderSection
  {
    protected override string GetAttributeTokenValue(string fieldName, Item item)
    {
      var field = FieldTypeManager.GetField(item?.Fields[fieldName]);
      if (field is ImageField)
      {
        return item.ImageFieldUrl(fieldName);
      }
      return base.GetAttributeTokenValue(fieldName, item);
    }
  }

  
}