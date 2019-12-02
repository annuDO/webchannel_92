
using Sitecore.Mvc.Presentation;
using System.Web.Mvc;
using Trelleborg.Feature.ContextSelector.Models;
using Trelleborg.Feature.ContextSelector.Repositories;

namespace Trelleborg.Feature.ContextSelector.Controllers
{
  public class MarketSelectorController : Controller
  {
    protected IMarketSelectorRepository MarketSelectorRepository { get; set; }
    public MarketSelectorController(IMarketSelectorRepository marketSelectorRepository)
    {
      MarketSelectorRepository = marketSelectorRepository;
    }
    

    public ActionResult MarketSelector()
    {
      var dataSourceId = RenderingContext.CurrentOrNull.Rendering.DataSource;
      var dataSource = Sitecore.Context.Database.GetItem(dataSourceId);
      var model = new MarketSelectorRenderingModel
      {
        ActiveLanguage = MarketSelectorRepository.GetActiveLanguageItem,
        RegionItems = MarketSelectorRepository.GetRegionItems(dataSource)
      };
      return this.View(model);
    }
  }
}