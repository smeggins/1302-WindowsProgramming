using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

public interface ILogger
{
    void logInformation(string message);
    void logError(string message);
    void logException(string message, Exception exception);
}

public class Logger : ILogger
{

    public void logError(string message)
    {
        var msg = String.Format("Log Error: {0}", message);
        write(msg);
    }

    public void logException(string message, Exception exception)
    {
        var msg = String.Format("Exception Logged: {0} {1}", message, exception);
        writeToFile("ExceptionLog/ExceptionLog.txt", msg);
    }

    public void logInformation(string message)
    {
        var msg = String.Format("Log Information: {0}", message);
        write(msg);
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
