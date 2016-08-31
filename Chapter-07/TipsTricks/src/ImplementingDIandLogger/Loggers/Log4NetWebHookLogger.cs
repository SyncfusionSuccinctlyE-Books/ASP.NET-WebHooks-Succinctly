using System;
using System.Web.Http.Tracing;
using log4net;
using Microsoft.AspNet.WebHooks.Diagnostics;

namespace ImplementingDIandLogger.Loggers
{
    //https://github.com/aspnet/WebHooks/blob/master/src/Microsoft.AspNet.WebHooks.Common/Diagnostics/ILogger.cs
    public class Log4NetWebHookLogger : ILogger
    {
        private static readonly ILog WebHookLogger = LogManager.GetLogger("WebHooks");

        public void Log(TraceLevel level, string message, Exception ex)
        {
            switch (level)
            {
                case TraceLevel.Fatal:
                    WebHookLogger.Fatal(message, ex);
                    break;

                case TraceLevel.Error:
                    WebHookLogger.Error(message, ex);
                    break;

                case TraceLevel.Warn:
                    WebHookLogger.Warn(message, ex);
                    break;

                case TraceLevel.Info:
                    WebHookLogger.Info(message, ex);
                    break;

                case TraceLevel.Debug:
                    WebHookLogger.Debug(message, ex);
                    break;
            }
        }
    }
}