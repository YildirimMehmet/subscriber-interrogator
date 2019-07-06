using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SubscriberInterrogator.Business.Helpers
{
    /// <summary>
    /// Logger
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Create log
        /// </summary>
        /// <param name="msg"></param>
        public static void LogMessage(string msg)
        {
            string targetPath = @"Logs";
            Directory.CreateDirectory(targetPath);
            string sFilePath = @"Logs/Log_" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-dd") + ".txt";
            
            StreamWriter sw = File.AppendText(sFilePath);
            try
            {
                string logLine = String.Format(
                    "{0:G}: {1}.", DateTime.Now, msg);
                sw.WriteLine(logLine);
            }
            finally
            {
                sw.Close();
            }
        }
    }
}
