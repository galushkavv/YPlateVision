using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace YPlateVision
{
    public static class Logger
    {
        public static string logFile;
        private static StreamWriter logWriter;

        public static void Write(string text, bool date = true, bool newline = true)
        {
            logFile = "log_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            logWriter = new StreamWriter(logFile, true);
            if(date) logWriter.Write(DateTime.Now.ToString("[HH:mm:ss] "));
            logWriter.Write(text);
            if (newline) logWriter.Write("\n");
            logWriter.Close();
        }
    }
}
