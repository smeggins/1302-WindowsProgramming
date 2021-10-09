using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CarBuilder
{
    private CarV2 car;
    private int vinNumber;
    private string brand;
    private string model;
    private int yearBuilt;
    private float milePer;

    public CarBuilder() { }
    public void addBrand(string brand) => this.brand = brand;
    public void addvinNumber(int vinNumber) => this.vinNumber = vinNumber;
    public void addmodel(string model) => this.model = model;
    public void addyearBuilt(int yearBuilt) => this.yearBuilt = yearBuilt;
    public void addmilePer(float milePer) => this.milePer = milePer;

    public CarV2 build(carTypes carType, GasCar.gasType gasType = GasCar.gasType.regular)
    {
        if (carType == carTypes.Electric)
        {
            car = new ElectricCar(vinNumber, brand, model, yearBuilt, milePer);
        }
        else if (carType == carTypes.Gas)
        {
            car = new GasCar(vinNumber, brand, model, yearBuilt, milePer, gasType);
        }
        else if (carType == carTypes.Hybrid)
        {
            car = new HybridCar(vinNumber, brand, model, yearBuilt, milePer, gasType);
        }
        else if (carType == carTypes.TimeMachine)
        {
            car = new TimeMachine(vinNumber, brand, model, yearBuilt, milePer);
        }

        return car;
    }

    public enum carTypes
    {
        Electric,
        Gas,
        Hybrid,
        TimeMachine
    }
}
