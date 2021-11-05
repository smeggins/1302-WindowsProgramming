using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DoomSlayer9000OmegaForce1
{
    public interface ILogger
    {
        void logInformation(string message);
        void logError(string message);
        void logException(string message, Exception exception);
    }

    public abstract class Logger : ILogger
    {
        public void logError(string message)
        {
            var msg = String.Format("Log Error: {0}", message);
            write(msg);
        }

        public void logException(string message, Exception exception)
        {
            var msg = String.Format("Exception Logged: {0} {1}", message, exception);
            write(msg);
        }

        public void logInformation(string message)
        {
            var msg = String.Format("Log Information: {0}", message);
            write(msg);
        }

        protected virtual void write(string message) { }
    }

    public class WriteLogger : ILogger
    {
        string rootPath = "Logs/";
        string exception = "ExceptionLogs/";
        string error = "ErrorLogs/";
        string information = "InformationLogs/";

        public void logError(string message)
        {
            var msg = String.Format("Log Error: {0}", message);
            writeToFile($"{rootPath}{error}errorLog.txt", msg);
        }

        public void logException(string message, Exception exception)
        {
            var msg = String.Format("Exception Logged: {0} {1}", message, exception);
            writeToFile($"{rootPath}{exception}ExceptionLog.txt", msg);
        }

        public void logInformation(string message)
        {
            var msg = String.Format("Log Information: {0}", message);
            writeToFile($"{rootPath}{information}InformationLog.txt", msg);
        }

        private void write(string message)
        {
            Console.WriteLine(message);
        }

        private void writeToFile(string fileLocation, string message)
        {
            File.WriteAllText(fileLocation, message);
        }
    }

    public class ConsoleLogger : ILogger
    {
        public void logError(string message)
        {
            write($"Log Error: {message}");
        }

        public void logException(string message, Exception exception)
        {
            write($"Exception Logged: {message} {exception}");
        }

        public void logInformation(string message)
        {
            write($"Log Information: {message}");
        }

        private void write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
