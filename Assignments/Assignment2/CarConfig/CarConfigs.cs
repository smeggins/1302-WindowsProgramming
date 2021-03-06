using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

public sealed class CarConfigs
{
    private List<CarConfig> configs;
    ILogger logger;
    private static readonly Lazy<CarConfigs> instance = new Lazy<CarConfigs>(() => new CarConfigs());

    private CarConfigs()
    {
        this.logger = new ConsoleLogger(); //defaults to log to console
        configs = new List<CarConfig>();
        load();
    }

    public static CarConfigs Instance
    {
        get { return instance.Value; }
    }

    public List<CarConfig> getConfigs()
    {
        return configs;
    }

    public void setLogger(ILogger logger)
    {
        this.logger = logger;
    }

    private void load()
    {
        try
        {
            XDocument configFile = XDocument.Load("Configs/Cars/configs.xml");

            foreach (var car in configFile.Descendants("car"))
            {
                string brand = car.Attributes().Where(e => e.Name == "brand").First().Value;
                string model = car.Attributes().Where(e => e.Name == "model").First().Value;
            
                int yearBuilt;
                int vin;
                float mileper;
                CarBuilder.carTypes carType;
                int.TryParse(car.Attributes().Where(e => e.Name == "yearBuilt").First().Value, out yearBuilt);
                int.TryParse(car.Attributes().Where(e => e.Name == "vin").First().Value, out vin);
                float.TryParse(car.Attributes().Where(e => e.Name == "mileper").First().Value, out mileper);
                CarBuilder.carTypes.TryParse(car.Attributes().Where(e => e.Name == "carType").First().Value, out carType);

                configs.Add(new CarConfig(brand, model, yearBuilt, vin, mileper, carType));
            }
        }
        catch (Exception ex)
        {
            logger.logException("Exception occurred while loading car configs from file:\n\n", ex);
        }
    }
}

public class CarConfig
{
    public string brand;
    public string model;
    public int yearBuilt;
    public int vin;
    public float mileper;
    public CarBuilder.carTypes carType;

    public CarConfig(   string brand, 
                        string model, 
                        int yearBuilt, 
                        int vin, 
                        float mileper, 
                        CarBuilder.carTypes carType)
    {
        this.brand = brand;
        this.model = model;
        this.yearBuilt = yearBuilt;
        this.vin = vin;
        this.mileper = mileper;
        this.carType = carType;
}
}