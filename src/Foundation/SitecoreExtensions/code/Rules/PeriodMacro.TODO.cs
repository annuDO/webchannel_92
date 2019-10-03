
using System.Xml.Linq;
using Sitecore;
using Sitecore.Diagnostics;
using Sitecore.Rules.RuleMacros;
using Sitecore.Shell.Applications.Dialogs.ItemLister;
using Sitecore.Text;
using Sitecore.Web.UI.Sheer;

namespace Trelleborg.Foundation.SitecoreExtensions
{
  //TODO:Enable if required
//  public class PeriodMacro : IRuleMacro

//{
//    public void Execute(XElement element, string name, UrlString parameters, string value)
//    {
//        Assert.ArgumentNotNull(element, "element");
//        Assert.ArgumentNotNull(name, "name");
//        Assert.ArgumentNotNull(parameters, "parameters");
//        Assert.ArgumentNotNull(value, "value");

//        var options = new SelectItemOptions();

//        if (!string.IsNullOrEmpty(value))
//        {
//            var item = Client.ContentDatabase.GetItem(value);

//            if (item != null)
//            {
//                options.SelectedItem = item;
//            }
//        }

//        options.Root = Client.ContentDatabase.GetItem("/sitecore/system/Settings/Rules/Definitions/Macros/Period");
//        options.Title = "Select Period";
//        options.Text = "Select the period type to use in this rule.";
//        options.Icon = "applications/32x32/media_stop.png";
//        options.ShowRoot = false;

//        SheerResponse.ShowModalDialog(options.ToUrlString().ToString(), true);
//    }
//}
}
