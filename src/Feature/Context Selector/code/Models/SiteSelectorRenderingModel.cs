using System;
using System.Collections.Generic;

namespace Trelleborg.Feature.ContextSelector.Models
{
  public class SiteSelectorRenderingModel
  {
    public List<SiteSelectorBU> SiteSelectorBUItems { get; set; }
  }

  public class SiteSelectorBU
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public string ShortDescription { get; set; }
    public ImageItem DetailImage { get; set; }
    public string SiteLink { get; set; }

  }

  public class ImageItem
  {
    public ImageItem()
    {
      Src = string.Empty;
      Title = string.Empty;
      Alt = string.Empty;
    }
    public String Src { get; set; }
    public String Title { get; set; }
    public String Alt { get; set; }
  }
}