using Sitecore.XA.Foundation.RenderingVariants.Fields;
using Sitecore.XA.Foundation.Variants.Abstractions.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;

namespace Trelleborg.Foundation.SitecoreExtensions
{
  public class VariantCustomResponsiveImage : VariantResponsiveImage
  {
    public VariantCustomResponsiveImage() : base()
    {
    }
    public string DesktopImageField { get; set; }
    public string MobileImageField { get; set; }
  }
}