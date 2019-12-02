using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using Trelleborg.Foundation.Logging.Infrastructure;

namespace Trelleborg.Feature.CustomContainers.Repositories
{
  public class ApiCisionRepository : IApiCisionRepository
  {

  public  object CallCisionApi(string address)
    {
      //var result = string.;
     // var context = HttpContext.Current;
      //try
      //{
      //  using (var webClient = new WebClient())
      //  {
      //    byte[] buffer = null;
      //    webClient.Headers.Clear();
      //    buffer = webClient.DownloadData(address);
      //    context.Response.Clear();
      //    result.Content = new StreamContent(new MemoryStream(buffer));
      //    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
      //    result.EnsureSuccessStatusCode();
      //  }
      //}
      //catch (HttpRequestException ex)
      //{
      //  Sitecore.Diagnostics.Log.Error(ex.Message, ex, "SitecoreLogFileAppenderEx");

      //}
      //catch (IOException ex)
      //{

      //  Sitecore.Diagnostics.Log.Error(ex.Message, ex, "SitecoreLogFileAppenderEx");
      //}
      HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);
      try
      {
        request.Accept = "application/json";
        //request.Method = HttpMethod.Get;
        WebResponse response = request.GetResponse();
        using (Stream responseStream = response.GetResponseStream())
        {

          StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
          
          return JsonConvert.DeserializeObject(reader.ReadToEnd());
        }
      }
      catch (WebException ex)
      {
        WebResponse errorResponse = ex.Response;
        using (Stream responseStream = errorResponse.GetResponseStream())
        {
          StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
          String errorText = reader.ReadToEnd();
          Sitecore.Diagnostics.Log.Error(errorText, ex, "SitecoreLogFileAppenderEx");
        }
      }
      return null;
    }
  }
}