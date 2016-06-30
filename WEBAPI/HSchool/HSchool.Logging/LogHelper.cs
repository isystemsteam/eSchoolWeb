using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Logging
{
    public static class LogHelper
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void Info(string message)
        {
            Logger.Info(message);
        }

        public static void Error(string message)
        {
            Logger.Error(message);
        }

        public static void Error(string message, Exception ex)
        {
            Logger.Error(message, ex);
        }

        public static void Debug(string message)
        {
            Logger.Debug(message);
        }

        public static void Debug(string message, Exception ex)
        {
            Logger.Debug(message, ex);
        }
    }
}
