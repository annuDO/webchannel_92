using System;

namespace Trelleborg.Foundation.Logging
{
    public interface ILogger
    {
        void WriteError(string message);
        void WriteError(string message, Exception ex);
        void WriteInfo(string message);
        void WriteDebug(string message);
        void WriteDebug(string message, Exception ex);
        void WriteWarning(string message);
        void WriteException(Exception ex);
    }
}
