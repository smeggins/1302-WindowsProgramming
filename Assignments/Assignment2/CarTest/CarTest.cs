using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class CarTest
{
    public static void test()
    {
        var dmc = new DMC(CarConfigs.Instance.getConfigs()[0].vin, CarConfigs.Instance.getConfigs()[0].yearBuilt);
        dmc.printRegistration();
        dmc.fuelUp(20000);
        
        Console.WriteLine("Vehicles flux capacitor is outputting 20,000 gigajouels of energy");
        Console.WriteLine("Vehicle can travel " + dmc.distanceOnFuel() + " miles on it's current tank of gas");

        var leaf = new Leaf(CarConfigs.Instance.getConfigs()[1].vin, CarConfigs.Instance.getConfigs()[1].yearBuilt);
        leaf.printRegistration();
        leaf.fuelUp(50);
        Console.WriteLine("Vehicle has 50 KWH of fuel");
        Console.WriteLine("Vehicle can travel " + leaf.distanceOnFuel() + " miles on it's current tank of gas");


        var model3 = new Model3(CarConfigs.Instance.getConfigs()[2].vin, CarConfigs.Instance.getConfigs()[2].yearBuilt);
        model3.printRegistration();
        model3.fuelUp(53);
        Console.WriteLine("Vehicle has 53 KWH of fuel");
        Console.WriteLine("Vehicle can travel " + model3.distanceOnFuel() + " miles on it's current tank of gas");


        var corolla = new Corolla(CarConfigs.Instance.getConfigs()[3].vin, CarConfigs.Instance.getConfigs()[3].yearBuilt);
        corolla.printRegistration();
        corolla.fuelUp(13);
        Console.WriteLine("Vehicle has 13 Galleons of fuel");
        Console.WriteLine("Vehicle can travel " + corolla.distanceOnFuel() + " miles on it's current tank of gas");
    }

    public static bool checkTestBuilder(CarV2 car, string brand, float mileper, string model, int vinNumber, int yearBuilt)
    {
        return (car.accessRegistration().brand == brand &&
                car.accessRegistration().model == model &&
                car.accessRegistration().vinNumber == vinNumber &&
                car.accessRegistration().yearBuilt == yearBuilt &&
                car.getMilePer() == mileper);
    }

    public static bool testBuilder(ILogger logger)
    {
        var builder = new CarBuilder(logger);
        var dmc = builder.addBrand(CarConfigs.Instance.getConfigs()[0].brand)
                        .addmilePer(CarConfigs.Instance.getConfigs()[0].mileper)
                        .addmodel(CarConfigs.Instance.getConfigs()[0].model)
                        .addvinNumber(CarConfigs.Instance.getConfigs()[0].vin)
                        .addyearBuilt(CarConfigs.Instance.getConfigs()[0].yearBuilt)
                        .build(CarBuilder.carTypes.TimeMachine);

        dmc.fuelUp(20000);
        logger.logInformation("Vehicles flux capacitor is outputting 20,000 gigajouels of energy");
        logger.logInformation("Vehicle can travel " + dmc.distanceOnFuel() + " miles on it's current tank of gas\n\n\n");

        builder = new CarBuilder(logger);
        var leaf = builder.addBrand(CarConfigs.Instance.getConfigs()[1].brand)
            .addmilePer(CarConfigs.Instance.getConfigs()[1].mileper)
            .addmodel(CarConfigs.Instance.getConfigs()[1].model)
            .addvinNumber(CarConfigs.Instance.getConfigs()[1].vin)
            .addyearBuilt(CarConfigs.Instance.getConfigs()[1].yearBuilt)
            .build(CarBuilder.carTypes.Electric);

        leaf.fuelUp(50);
        logger.logInformation("Vehicle has 50 KWH of fuel");
        logger.logInformation("Vehicle can travel " + leaf.distanceOnFuel() + " miles on it's current tank of gas\n\n\n");

        builder = new CarBuilder(logger);
        var model3 = builder.addBrand(CarConfigs.Instance.getConfigs()[2].brand)
            .addmilePer(CarConfigs.Instance.getConfigs()[2].mileper)
            .addmodel(CarConfigs.Instance.getConfigs()[2].model)
            .addvinNumber(CarConfigs.Instance.getConfigs()[2].vin)
            .addyearBuilt(CarConfigs.Instance.getConfigs()[2].yearBuilt)
            .build(CarBuilder.carTypes.Electric);

        model3.fuelUp(53);
        logger.logInformation("Vehicle has 53 KWH of fuel");
        logger.logInformation("Vehicle can travel " + model3.distanceOnFuel() + " miles on it's current tank of gas\n\n\n");

        builder = new CarBuilder(logger);
        var corolla = builder.addBrand(CarConfigs.Instance.getConfigs()[3].brand)
            .addmilePer(CarConfigs.Instance.getConfigs()[3].mileper)
            .addmodel(CarConfigs.Instance.getConfigs()[3].model)
            .addvinNumber(CarConfigs.Instance.getConfigs()[3].vin)
            .addyearBuilt(CarConfigs.Instance.getConfigs()[3].yearBuilt)
            .build(CarBuilder.carTypes.Gas);
        
        corolla.fuelUp(13);
        logger.logInformation("Vehicle has 13 Galleons of fuel");
        logger.logInformation("Vehicle can travel " + corolla.distanceOnFuel() + " miles on it's current tank of gas\n\n\n");

        return (checkTestBuilder(dmc, "DeLorean", 20, "DMC-12", 543231, 1981) &&
                checkTestBuilder(leaf, "Nissan", 0.3f, "Leaf", 234564, 2021) &&
                checkTestBuilder(model3, "Tesla", 0.31f, "3", 954324, 2022) &&
                checkTestBuilder(corolla, "Toyota", 33, "Corolla", 732556, 2013));
    }

    public static void buildException(ILogger logger)
    {
        var builder = new CarBuilder(logger);
        var dmc = builder.addBrand(CarConfigs.Instance.getConfigs()[0].brand)
                        .addmilePer(CarConfigs.Instance.getConfigs()[0].mileper)
                        .addmodel(CarConfigs.Instance.getConfigs()[0].model)
                        ////////////////////////////////////////////////////
                        // missing vin number should throw exception:
                        //.addvinNumber(CarConfigs.Instance.getConfigs()[0].vin)
                        ////////////////////////////////////////////////////
                        .addyearBuilt(CarConfigs.Instance.getConfigs()[0].yearBuilt)
                        .build(CarBuilder.carTypes.TimeMachine);

        dmc.fuelUp(20000);
        logger.logInformation("Vehicles flux capacitor is outputting 20,000 gigajouels of energy");
        logger.logInformation("Vehicle can travel " + dmc.distanceOnFuel() + " miles on it's current tank of gas\n\n\n");

    }
}
