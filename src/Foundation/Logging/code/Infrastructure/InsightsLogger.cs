using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Azure;
using Trelleborg.Foundation.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Trelleborg.Foundation.Logging
{
  /// <summary>
  /// Helper class for app insights telemetry events.
  /// Allows tracking page views, exceptions and other telemetry through the Microsoft Application Insights service.
  /// </summary>
  [Service(typeof(ILogger))]
  public class InsightsLogger : ILogger
  {
    public enum LoggingLevel { Verbose, Debug, Info, Warning, Error };

    private const string ApplicationName = "ApplicationName";
    private static TelemetryClient insightsTelementry;
    private static LoggingLevel loggingLevel = LoggingLevel.Error;
    private static readonly object threadlock = new object();

    static InsightsLogger()
    {
      if (insightsTelementry == null)
      {
        lock (threadlock)
        {
          if (insightsTelementry == null)
          {
            TelemetryConfiguration.Active.InstrumentationKey = CloudConfigurationManager.GetSetting("AppInsightsInstrumentationKey");
            new TelemetryClient().TrackEvent("AppStart", AddCommonProperties());
            insightsTelementry = new TelemetryClient();
            loggingLevel = (LoggingLevel)Enum.Parse(typeof(LoggingLevel), CloudConfigurationManager.GetSetting("LoggingLevel"));
          }
        }
      }
    }

    /// <summary>
    /// Helper private method to add additional common properties to all telemetry events via ref param
    /// </summary>
    /// <param name="properties">original properties to add to</param>
    private static Dictionary<string, string> AddCommonProperties()
    {
      // add common properties as long as they don't already exist in the original properties passed in
      Dictionary<string, string> properties = new Dictionary<string, string>();
      if (!properties.ContainsKey("Application Name"))
      {
        properties.Add("Application Name", CloudConfigurationManager.GetSetting(ApplicationName));
      }
      return properties;
    }

    /// <summary>
    ///  Trace and track custom web app insights event with global common properities,
    ///  with severity level Verbose to identify in trace telemetry
    /// </summary>
    /// <param name="message">Trace message to be log in trace telemetry</param>
    /// <param name="ex">exception caused during the application execution</param>
    public void WriteDebug(string message)
    {
      if (loggingLevel > LoggingLevel.Debug)
        return;
      insightsTelementry.TrackTrace(message, SeverityLevel.Verbose, AddCommonProperties());
      insightsTelementry.Flush();
    }

    /// <summary>
    ///  Trace and track custom web app insights event with global common properities,
    ///  with severity level Verbose to identify in trace telemetry
    /// </summary>
    /// <param name="message">Trace message to be log in trace telemetry</param>
    /// <param name="ex">exception caused during the application execution</param>
    public void WriteDebug(string message, Exception ex)
    {
      if (loggingLevel > LoggingLevel.Debug)
        return;
      insightsTelementry.TrackTrace(message, SeverityLevel.Verbose, AddCommonProperties());
      insightsTelementry.Flush();
    }

    /// <summary>
    ///  Trace and track custom web app insights Error event with global common properities,
    ///  with severity level Error to identify in trace telemetry
    /// </summary>
    /// <param name="message">Trace message to be log in trace telemetry</param>
    /// <param name="ex">exception caused during the application execution</param>
    public void WriteError(string message)
    {
      insightsTelementry.TrackTrace(message, SeverityLevel.Error, AddCommonProperties());
      insightsTelementry.Flush();
    }

    /// <summary>
    ///  Trace and track custom web app insights Error event with global common properities,
    ///  with severity level Error to identify in trace telemetry
    /// </summary>
    /// <param name="message">Trace message to be log in trace telemetry</param>
    /// <param name="ex">exception caused during the application execution</param>
    public void WriteError(string message, Exception ex)
    {
      insightsTelementry.TrackTrace(message, SeverityLevel.Error, AddCommonProperties());
      insightsTelementry.Flush();
      WriteException(ex);
    }

    /// <summary>
    /// Log and track custom web app insights exception event with global common properities
    /// </summary>
    /// <param name="ex">exception caused during the application execution</param>
    public void WriteException(Exception ex)
    {
      insightsTelementry.TrackException(ex, AddCommonProperties());
      insightsTelementry.Flush();
    }

    /// <summary>
    ///  Trace and track custom web app insights Information event with global common properities,
    ///  with severity level Information to identify in trace telemetry
    /// </summary>
    /// <param name="message">Trace message to be log in trace telemetry</param>
    public void WriteInfo(string message)
    {
      insightsTelementry.TrackTrace(message, SeverityLevel.Information, AddCommonProperties());
      insightsTelementry.Flush();
    }

    /// <summary>
    ///  Trace and track custom web app insights Warning event with global common properities,
    ///  with severity level Warning to identify in trace telemetry
    /// </summary>
    /// <param name="message">Trace message to be log in trace telemetry</param>
    public void WriteWarning(string message)
    {
      if (loggingLevel >= LoggingLevel.Warning)
        return;
      insightsTelementry.TrackTrace(message, SeverityLevel.Warning);
      insightsTelementry.Flush();
    }
  }
}
