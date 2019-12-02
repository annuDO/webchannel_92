using Sitecore.Pipelines;
using System.Web.Routing;

namespace Trelleborg.Feature.CustomContainers.Pipelines.Initialize
{
    public class InitializeRouting
    {
        public void Process(PipelineArgs args)
        {
            if (!Sitecore.Context.IsUnitTesting)
            {
                RouteConfig.RegisterRoutes(RouteTable.Routes);
            }
        }
    }
}