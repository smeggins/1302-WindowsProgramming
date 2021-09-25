using System;
using System.Collections.Generic;
using System.Text;


public interface ILogger
{
    void logInformation(string message);
    void logError(string message);
    void logException(string message, Exception exception);
}

public static class Logger : ILogger
{

    public static void logError(string message)
    {
        var msg = String.Format("Log Error: {0}", message);
        write(msg);

    }

    public static void logException(string message, Exception exception)
    {
        var msg = String.Format("Log Exception: {0}", message);
        write(msg);

    }

    public static void logInformation(string message)
    {
        var msg = String.Format("Log Information: {0}", message);
        write(msg);
    }

    private static void write(string message)
    {
        Console.WriteLine(message);
    }

}
