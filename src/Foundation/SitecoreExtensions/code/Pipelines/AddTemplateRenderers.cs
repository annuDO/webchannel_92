using Trelleborg.Foundation.SitecoreExtensions.NVelocity;
using Sitecore.XA.Foundation.Variants.Abstractions.Pipelines.GetVelocityTemplateRenderers;

namespace Trelleborg.Foundation.SitecoreExtensions.Pipelines
{
  public class AddTemplateRenderers : IGetTemplateRenderersPipelineProcessor
  {
    public void Process(GetTemplateRenderersPipelineArgs args)
    {
      args?.Context.Put("fieldTokens", new FieldTokens());
    }
  }
}