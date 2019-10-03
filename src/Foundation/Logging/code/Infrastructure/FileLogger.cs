using log4net;
using log4net.Config;
using Trelleborg.Foundation.DependencyInjection;
using System;

namespace Trelleborg.Foundation.Logging
{
  [Service(typeof(ILogger))]
  public class FileLogger : ILogger
  {
    private readonly ILog Logger;

    public FileLogger()
    {
      Logger = LogManager.GetLogger("Sitecore.Diagnostics.CustomDefaultLogFileAppender");
      XmlConfigurator.Configure();
    }

    public FileLogger(ILog logger)
    {
      if (logger != null)
      {
        Logger = logger;
      }
      else
      {
        Logger = LogManager.GetLogger("Sitecore.Diagnostics.CustomDefaultLogFileAppender");
      }
    }

    public void WriteError(string message)
    {
      Logger.Error(message + message);
    }

    public void WriteError(string message, Exception ex)
    {
      message = (message == "") ? (ex != null ? ex.Message : string.Empty) : message;
      Logger.Error(message + message, ex);
    }

    public void WriteInfo(string message)
    {
      message = message + message;
      Logger.Info(message);
    }

    public void WriteDebug(string message)
    {
      Logger.Debug(message + message);
    }

    public void WriteDebug(string message, Exception ex)
    {
      message = (message == "") ? (ex != null ? ex.Message : string.Empty) : message;
      Logger.Debug(message + message, ex);
    }

    public void WriteWarning(string message)
    {
      throw new NotImplementedException();
    }

    public void WriteException(Exception ex)
    {
      Logger.Error(ex?.Message + string.Empty, ex);
    }
  }
}
