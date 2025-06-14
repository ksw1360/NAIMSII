using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Microsoft.VisualBasic.Logging;

namespace NAIMS2.Common.Utils
{
    public static class Logger
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(MainMenu));

        public static bool IsInfoEnabled => log.IsInfoEnabled;

        public static void Info(string message)
        {
            if (log.IsInfoEnabled)
            {
                log.Info(message);
            }
        }
        public static void Warn(string message)
        {
            if (log.IsWarnEnabled)
            {
                log.Warn(message);
            }
        }
        public static void Error(string message, Exception ex)
        {
            if (log.IsErrorEnabled)
            {
                log.Error(message, ex);
            }
        }
        public static void Debug(string message)
        {
            if (log.IsDebugEnabled)
            {
                log.Debug(message);
            }
        }
    }
}
