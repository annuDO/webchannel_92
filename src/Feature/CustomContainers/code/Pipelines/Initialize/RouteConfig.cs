using System.Web.Mvc;
using System.Web.Routing;

namespace Trelleborg.Feature.CustomContainers.Pipelines.Initialize
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("api-cision-ticker", "apiv2/Cision/Ticker", new { controller = "ApiCision", action = "FetchTicketDetails", id = UrlParameter.Optional });
        }
    }
}