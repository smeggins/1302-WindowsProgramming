using System;
using System.Collections.Generic;
using System.Text;

// to use this you need to make the logger non-static
//public interface ILogger
//{
//    void logInformation(string message);
//    void logError(string message);
//    void logException(string message, Exception exception);
//}

public static class Logger
{

    public static void logError(string message)
    {
        var msg = String.Format("Log Error: {0}", message);
        write(msg);
    }

    public static void logException(string message, Exception exception)
    {
        var msg = String.Format("Log Exception: {0} {1}", message, exception);
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

    public static void test()
    {
        string test = null;
        try
        {
            if (string.IsNullOrEmpty(test))
            {
                throw new ArgumentException(nameof(test), "test cannot be null or empty");
            }
        }
        catch(Exception ex)
        {
            Logger.logException("test exception in logger....", ex);
        }
        
    }

    //public static void testnonStatic()
    //{
    //    // the benefit of this is you are passing an instantiated
    //    // instance of the interface
    //    public testInterface(ILogger logger)
    //    {
    //        this.logger = logger
    //    }
    //}
}
