using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;
using Trelleborg.Feature.CustomContainers.Repositories;

namespace Trelleborg.Feature.CustomContainers.Controllers
{
  public class ApiCisionController : Controller
  {
    protected IApiCisionRepository ApiCisionRepository { get; set; }
    public ApiCisionController(IApiCisionRepository apiCisionRepository)
    {
      ApiCisionRepository = apiCisionRepository;
    }

   
    public ActionResult FetchTicketDetails()
    {
      try
      {
        var address = ConfigurationManager.AppSettings["CisionTickerAddress"];
        var result = ApiCisionRepository.CallCisionApi(address);
        return result != null ? Content(result.ToString(), "application/json", Encoding.UTF8) : null;

      }
      catch (Exception ex)
      {

        Sitecore.Diagnostics.Log.Error(ex.Message, ex, "SitecoreLogFileAppenderEx");
      }
      return null;
    }
  }
}