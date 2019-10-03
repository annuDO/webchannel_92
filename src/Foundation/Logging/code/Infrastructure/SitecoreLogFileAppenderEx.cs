using log4net.spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trelleborg.Foundation.Logging.Infrastructure
{
  public class SitecoreLogFileAppenderEx : log4net.Appender.SitecoreLogFileAppender
  {
    protected override void Append(LoggingEvent loggingEvent)
    {

      var properties = loggingEvent.Properties;

      properties["sccontextsite"] = Sitecore.Context.Site.Name;

      base.Append(loggingEvent);
    }
  }
}