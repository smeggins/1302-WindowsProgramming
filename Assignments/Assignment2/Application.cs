using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

class Application
{
    static void Main(string[] args)
    {
        var logger = logLoader();
        Console.WriteLine($"testFactory Passed Test: {CarTest.testFactory(logger)}");
        CarConfigs.Instance.setLogger(logger);
    }

    public static ILogger logLoader()
    {
        ILogger returnLogger = new WriteLogger();
        try
        {
            XDocument configFile = XDocument.Load("Configs/Logger/configs.xml");
            string loggerType = configFile.Root.Attribute("type").Value;
            if (loggerType == "writeLog"){}
            else if (loggerType == "consoleLog")
            {
                returnLogger = new ConsoleLogger();
            }
            else
            {
                throw new ArgumentException("invalid logger type");
            }
        }
        catch (Exception ex)
        {
            returnLogger.logException("Exception occurred while loading logger config:\n\n", ex);
        }

        return returnLogger;
    }
}
