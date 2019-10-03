using System.Web;
using Sitecore.Mvc.Pipelines.Request.RequestBegin;
using System.Linq;
using Trelleborg.Utilities.Auth;


namespace Trelleborg.Utilities.Pipelines.MvcRequestBeginProcessors
{
  //TODO:Implement OAuth
    //class OauthMvcRequestBeginProcessor : RequestBeginProcessor
    //{
    //    public override void Process(RequestBeginArgs args)
    //    {
    //        // Check if the site requires oauth 
    //        string[] enable = global::Sitecore.Configuration.Settings.GetSetting("EnableOauth").Split('|');
    //        // Check if the session object is existing and also check for which Site the oauth code has to be triggered 
    //        if (HttpContext.Current != null && HttpContext.Current.Session != null && enable.Contains(Sitecore.Context.Site.Name))
    //        {
    //            // start the oauth process
    //            var oAuthrepo = new OauthRepository();
    //            bool Virtualuser = oAuthrepo.SCSessionCreation();
    //        }
    //    }
    //}
}
