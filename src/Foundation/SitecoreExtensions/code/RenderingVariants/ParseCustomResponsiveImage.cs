using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.DependencyInjection;
using Sitecore.XA.Foundation.SitecoreExtensions.Extensions;
using Sitecore.XA.Foundation.Variants.Abstractions.Pipelines.ParseVariantFields;
using Sitecore.XA.Foundation.Variants.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trelleborg.Foundation.SitecoreExtensions
{
  public class ParseCustomResponsiveImage : ParseVariantFieldProcessor
  {
    public override ID SupportedTemplateId => new ID("{6D243917-2613-4E13-9406-7EEB1601F3A9}");

    public override void TranslateField(ParseVariantFieldArgs args)
    {
      ParseVariantFieldArgs variantFieldArgs = args;
      VariantCustomResponsiveImage variantResponsiveImage = new VariantCustomResponsiveImage
      {
        ItemName = args?.VariantItem.Name,
        DesktopImageField = args?.VariantItem[new ID("{E35261A9-57C6-4B33-BEB7-A44F9BBA9B29}")],
        MobileImageField = args?.VariantItem[new ID("{D1ED5BBF-F65E-42E5-9F16-A201B88FD187}")],
        Sizes = args?.VariantItem[new ID("{700C0ACD-3FE2-49E5-884E-6F4E5D38F93C}")],
        Widths = args?.VariantItem[new ID("{4EC297EA-EC0C-49CC-9C83-7BE822CF88A5}")],
        DefaultSize = args?.VariantItem[new ID("{2A95C878-DCB1-4EC0-AD91-B40643515A10}")]
      };
      variantFieldArgs.TranslatedField = variantResponsiveImage;
    }

  }

}