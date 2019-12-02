using Sitecore.Mvc.Presentation;
using System.Web.Mvc;
using Trelleborg.Feature.ContextSelector.Models;
using Trelleborg.Feature.ContextSelector.Repositories;

namespace Trelleborg.Feature.ContextSelector.Controllers
{
  public class SiteController : Controller
  {
    protected ISiteSelectorRepository SiteSelectorRepository { get; set; }
    public SiteController(ISiteSelectorRepository siteSelectorRepository)
    {
      SiteSelectorRepository = siteSelectorRepository;
    }

    public ActionResult SiteSelector()
    {
      var dataSourceId = RenderingContext.CurrentOrNull.Rendering.DataSource;
      var dataSource = Sitecore.Context.Database.GetItem(dataSourceId);
      var model = new SiteSelectorRenderingModel
      {
        SiteSelectorBUItems = SiteSelectorRepository.GetSiteSelectorBUItems(dataSource)
      };
      return this.View(model);
    }
  }
}