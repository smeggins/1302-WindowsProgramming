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

    public static void testBuilder()
    {
        var builder = new CarBuilder();
        builder.addBrand(CarConfigs.Instance.getConfigs()[0].brand);
        builder.addmilePer(CarConfigs.Instance.getConfigs()[0].mileper);
        builder.addmodel(CarConfigs.Instance.getConfigs()[0].model);
        builder.addvinNumber(CarConfigs.Instance.getConfigs()[0].vin);
        builder.addyearBuilt(CarConfigs.Instance.getConfigs()[0].yearBuilt);

        var dmc = builder.build(CarBuilder.carTypes.TimeMachine);
        dmc.printRegistration();
        dmc.fuelUp(20000);
        Console.WriteLine("Vehicles flux capacitor is outputting 20,000 gigajouels of energy");
        Console.WriteLine("Vehicle can travel " + dmc.distanceOnFuel() + " miles on it's current tank of gas");

        builder = new CarBuilder();
        builder.addBrand(CarConfigs.Instance.getConfigs()[1].brand);
        builder.addmilePer(CarConfigs.Instance.getConfigs()[1].mileper);
        builder.addmodel(CarConfigs.Instance.getConfigs()[1].model);
        builder.addvinNumber(CarConfigs.Instance.getConfigs()[1].vin);
        builder.addyearBuilt(CarConfigs.Instance.getConfigs()[1].yearBuilt);

        var leaf = builder.build(CarBuilder.carTypes.Electric);
        leaf.printRegistration();
        leaf.fuelUp(50);
        Console.WriteLine("Vehicle has 50 KWH of fuel");
        Console.WriteLine("Vehicle can travel " + leaf.distanceOnFuel() + " miles on it's current tank of gas");

        builder = new CarBuilder();
        builder.addBrand(CarConfigs.Instance.getConfigs()[2].brand);
        builder.addmilePer(CarConfigs.Instance.getConfigs()[2].mileper);
        builder.addmodel(CarConfigs.Instance.getConfigs()[2].model);
        builder.addvinNumber(CarConfigs.Instance.getConfigs()[2].vin);
        builder.addyearBuilt(CarConfigs.Instance.getConfigs()[2].yearBuilt);

        var model3 = builder.build(CarBuilder.carTypes.Electric);
        model3.printRegistration();
        model3.fuelUp(53);
        Console.WriteLine("Vehicle has 53 KWH of fuel");
        Console.WriteLine("Vehicle can travel " + model3.distanceOnFuel() + " miles on it's current tank of gas");

        builder = new CarBuilder();
        builder.addBrand(CarConfigs.Instance.getConfigs()[3].brand);
        builder.addmilePer(CarConfigs.Instance.getConfigs()[3].mileper);
        builder.addmodel(CarConfigs.Instance.getConfigs()[3].model);
        builder.addvinNumber(CarConfigs.Instance.getConfigs()[3].vin);
        builder.addyearBuilt(CarConfigs.Instance.getConfigs()[3].yearBuilt);

        var corolla = builder.build(CarBuilder.carTypes.Gas);
        corolla.printRegistration();
        corolla.fuelUp(13);
        Console.WriteLine("Vehicle has 13 Galleons of fuel");
        Console.WriteLine("Vehicle can travel " + corolla.distanceOnFuel() + " miles on it's current tank of gas");
    }
}
