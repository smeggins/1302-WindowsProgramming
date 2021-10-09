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
    private static readonly Lazy<CarConfigs> instance = new Lazy<CarConfigs>(() => new CarConfigs());

    private CarConfigs()
    {
        configs = new List<CarConfig>();
        load();
    }

    public                                                                                                                                                            static CarConfigs Instance
    {
        get { return instance.Value; }
    }

    public List<CarConfig> getConfigs()
    {
        return configs;
    }

    private void load()
    {
        XDocument configFile = XDocument.Load("CarConfigs/configs.xml");

        foreach (var car in configFile.Descendants("car"))
        {
            string brand = car.Attributes().Where(e => e.Name == "brand").First().Value;
            string model = car.Attributes().Where(e => e.Name == "model").First().Value;
            
            int yearBuilt;
            int vin;
            int mileper;
            int.TryParse(car.Attributes().Where(e => e.Name == "yearBuilt").First().Value, out yearBuilt);
            int.TryParse(car.Attributes().Where(e => e.Name == "vin").First().Value, out vin);
            int.TryParse(car.Attributes().Where(e => e.Name == "mileper").First().Value, out mileper);

            configs.Add(new CarConfig(brand, model, yearBuilt, vin, mileper));
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

    public CarConfig(string brand, string model, int yearBuilt, int vin, float mileper)
    {
        this.brand = brand;
        this.model = model;
        this.yearBuilt = yearBuilt;
        this.vin = vin;
        this.mileper = mileper;
    }
}