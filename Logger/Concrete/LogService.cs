using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Abstract;

namespace Logger.Concrete
{
    public class LogService :ILogger
    {
        private static LogService _logger;

        private LogService()
        {
            
        }

        public static LogService GetLogger()
        {
            if (_logger == null)
            {
                _logger = new LogService();
            }
            return _logger;
        }

        public void LogMessage(string message)
        {
            var filePath = @"C:\Experiments\Logs\LogData.txt";

            string fileName = string.Format("{0}_{1}.log", "Log", DateTime.Now.ToShortDateString());

            string logFilePath = string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, fileName);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" ");
            sb.AppendLine("----------------------------------------");
            sb.AppendLine(" ");
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine(message);
            sb.AppendLine(" ");
            sb.AppendLine("----------------------------------------");
            sb.AppendLine(" ");
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.Write(sb.ToString());
                writer.Flush();
            }
        }
    }
}
