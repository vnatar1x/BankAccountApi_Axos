using System;
using System.IO;
using System.Configuration;

namespace BanAccountApi_Logging.Implementations
{
    public class LogBase
    {
        static StreamWriter _fStreamWriter;

        static LogBase()
        {
            string logFilePath = ConfigurationManager.AppSettings["LogFilePath"];

            string fileName = logFilePath + "log" + "_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

            _fStreamWriter = new StreamWriter(new FileStream(fileName, FileMode.Append, FileAccess.Write));
        }

        public static void WriteLog(string message)
        {
            if (_fStreamWriter != null)
            {
                _fStreamWriter.WriteLine(message + " at " + DateTime.Now.ToString());
                _fStreamWriter.Flush();
            }
        }

        ~LogBase()
        {
            if (_fStreamWriter != null)
            {
                _fStreamWriter.Close();
                _fStreamWriter = null;
            }
        }
    }
}
