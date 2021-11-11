using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MegaDeathMountain
{
    public interface ILogger
    {
        void logDebugInformation(string message);
        void logError(string message);
        void logException(string message, Exception exception);
    }

    public abstract class Logger : ILogger
    {
        public virtual void logError(string message)
        {
            var msg = String.Format("Log Error: {0}", message);
            write(msg);
        }

        public virtual void logException(string message, Exception exception)
        {
            var msg = String.Format("Exception Logged: {0} {1}", message, exception);
            write(msg);
        }

        public virtual void logDebugInformation(string message)
        {
            if (Game.debugMode == true)
            {
                var msg = String.Format("Log debug Information: {0}", message);
                write(msg);
            }
        }

        protected abstract void write(string message, string fileLocation="");
    }

    public class WriteLogger : Logger
    {
        string rootPath = "Logs/";
        string exceptionPath = "ExceptionLogs/";
        string errorPath = "ErrorLogs/";
        string informationPath = "DebugLogs/";

        public WriteLogger()
        {
            Console.WriteLine("creating files>");
            using (File.Create(rootPath + errorPath + "errorLog.txt")) ;
            using (File.Create(rootPath + exceptionPath + "exceptionLog.txt")) ;
            using (File.Create(rootPath + informationPath + "debugLog.txt"));
        }

        public override void logError(string message)
        {
            var msg = String.Format("Log Error: {0}", message);
            write(msg, rootPath + errorPath + "errorLog.txt");
        }

        public override void logException(string message, Exception exception)
        {
            var msg = String.Format("Exception Logged: {0} {1}", message, exception);
            write(msg, rootPath + exceptionPath + "exceptionLog.txt");
        }

        public override void logDebugInformation(string message)
        {
            if (Game.debugMode == true)
            {
                var msg = String.Format("Log debug Information: {0}", message);
                write(msg, rootPath + informationPath + "debugLog.txt");
            }        
        }

        protected override void write(string message, string fileLocation)
        {
            Console.WriteLine($"total path: {fileLocation}");

            File.AppendAllText(fileLocation, message);
        }
    }

    public class ConsoleLogger : Logger
    {
        protected override void write(string message, string fileLocation = "")
        {
            Console.WriteLine(message);
            UILineManager.waitForEnter();
        }
    }
}
