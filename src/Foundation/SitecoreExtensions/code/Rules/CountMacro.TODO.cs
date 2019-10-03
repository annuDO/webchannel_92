using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
using Sitecore.Diagnostics;
using Sitecore.Globalization;
using Sitecore.Rules.RuleMacros;
using Sitecore.Text;
using Sitecore.Web.UI.Sheer;

namespace Trelleborg.Foundation.SitecoreExtensions
{
  //TODO:Enable if required
  //public class CountMacro : IRuleMacro
  //  {
    
  //      public void Execute(XElement element, string name, UrlString parameters, string value)
  //      {
  //          Assert.ArgumentNotNull(element, "element");
  //          Assert.ArgumentNotNull(name, "name");
  //          Assert.ArgumentNotNull(parameters, "parameters");
  //          Assert.ArgumentNotNull(value, "value");

  //          var validation = "^([2-9]{1}|[0-9]{2}?|[12][0-9][0-9]|3[0-5][0-9]|36[0-5])$";
  //          var key = "Please enter a valid positive value from 2 to 365.";
  //          var result = 0;

  //          try
  //          {
  //              if (parameters.Parameters["validation"] != null)
  //              {
  //                  validation = HttpUtility.UrlDecode(parameters.Parameters["validation"]);
  //              }

  //              if (parameters.Parameters["validationText"] != null)
  //              {
  //                  key = HttpUtility.UrlDecode(parameters.Parameters["validationText"]);
  //              }

  //              if (parameters.Parameters["maxLength"] != null)
  //              {
  //                  int.TryParse(parameters.Parameters["maxLength"], out result);
  //              }
  //          }
  //          catch (Exception exception)
  //          {
  //              Log.Error(exception.Message, this);
  //          }

  //          SheerResponse.Input("Enter value", value, validation, Translate.Text(key), result);
  //      }
  //  }
}

