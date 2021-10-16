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
    private ILogger logger;

    public CarBuilder(ILogger logger)
    {
        this.logger = logger;
    }
    public CarBuilder addBrand(string brand)
    { 
        this.brand = brand;
        logger.logInformation($"Adding Brand: {brand}");
        
        return this;
    }
    public CarBuilder addvinNumber(int vinNumber)
    {
        this.vinNumber = vinNumber;
        logger.logInformation($"Adding Brand: {brand}");

        return this;
    }
    public CarBuilder addmodel(string model)
    {
        this.model = model;
        logger.logInformation($"Adding vinNumber: {vinNumber}");

        return this;
    }

    public CarBuilder addyearBuilt(int yearBuilt) 
    {
        this.yearBuilt = yearBuilt;
        logger.logInformation($"Adding yearBuilt: {yearBuilt}");

        return this;
    }
    public CarBuilder addmilePer(float milePer)
    {
        this.milePer = milePer;
        logger.logInformation($"Adding milePer: {milePer}");

        return this;
    }

    private bool readyToBuild()
    {
        return (vinNumber != 0 && brand != "" && model != "" && yearBuilt != 0);
    }

    public CarV2 build(carTypes carType, GasCar.gasType gasType = GasCar.gasType.regular)
    {
        try
        {
            if (!readyToBuild())
            {
                throw new ArgumentException("\nmissing value when building car." +
                    "\nValues Given:" +
                    "\n   vinNumber: " + vinNumber +
                    "\n   brand: " + brand +
                    "\n   model: " + model +
                    "\n   yearBuilt: " + yearBuilt);
            }

            if (carType == carTypes.Electric)
            {
                car = new ElectricCar(vinNumber, brand, model, yearBuilt, milePer);
                logger.logInformation($"\n\nBuilding an electric car with the following details:\n{car.getRegistration()}");
            }
            else if (carType == carTypes.Gas)
            {
                car = new GasCar(vinNumber, brand, model, yearBuilt, milePer, gasType);
                logger.logInformation($"\n\nBuilding a gas car with the following details:\n{car.getRegistration()}");

            }
            else if (carType == carTypes.Hybrid)
            {
                car = new HybridCar(vinNumber, brand, model, yearBuilt, milePer, gasType);
                logger.logInformation($"\n\nBuilding a hybrid car with the following details:\n{car.getRegistration()}");

            }
            else if (carType == carTypes.TimeMachine)
            {
                car = new TimeMachine(vinNumber, brand, model, yearBuilt, milePer);
                logger.logInformation($"\n\nBuilding a TimeMachine Marty!... with the following details:\n{car.getRegistration()}");

            }
        }
        catch (Exception ex)
        {
            logger.logException("\n\n ************\n\ntest exception in logger....", ex);
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
