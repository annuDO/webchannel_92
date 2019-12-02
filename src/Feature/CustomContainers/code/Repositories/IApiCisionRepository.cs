using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Trelleborg.Feature.CustomContainers.Repositories
{
  public interface IApiCisionRepository
  {
    object CallCisionApi(string address);
  }
}