using AutomationFramework.Config;
using System;
using System.IO;

namespace AutomationFramework.Helpers
{
    public class LogHelpers
    {


        //Dynamic Log File Name
        private static string _logFileName = string.Format("SeleniumAutomationLogFile_{0: yyyymmddhhmmss}", DateTime.Now);
        private static StreamWriter _streamw = null;

        //Create a File which can store a log information
        public static void CreateLogFile()
        {

            //string dir = Environment.CurrentDirectory+"/Data/";
            string dir = Settings.LogPath;

            if (Directory.Exists(dir))
            {
                _streamw = File.AppendText(dir + _logFileName + ".log");
            }
            else
            {
                Directory.CreateDirectory(dir);
                _streamw = File.AppendText(dir + _logFileName + ".log");
            }

        }

        //Create a Method which can write a text in the log file

        public static void WriteLine(string logMessage)
        {
            _streamw.Write("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            _streamw.WriteLine("  -  {0}", logMessage);
            _streamw.Flush();
        }



    }
}
