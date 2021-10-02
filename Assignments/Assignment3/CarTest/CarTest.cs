using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class CarTest
{
    public static void test()
    {
        var dmc = new DMC(CarConfig1.vin, CarConfig1.yearBuilt);
        dmc.printRegistration();
        dmc.fuelUp(20000);
        Console.WriteLine("Vehicles flux capacitor is outputting 20,000 gigajouels of energy");
        Console.WriteLine("Vehicle can travel " + dmc.distanceOnFuel() + " miles on it's current tank of gas");

        var leaf = new Leaf(CarConfig2.vin, CarConfig2.yearBuilt);
        leaf.printRegistration();
        leaf.fuelUp(50);
        Console.WriteLine("Vehicle has 50 KWH of fuel");
        Console.WriteLine("Vehicle can travel " + leaf.distanceOnFuel() + " miles on it's current tank of gas");


        var model3 = new Model3(CarConfig3.vin, CarConfig3.yearBuilt);
        model3.printRegistration();
        model3.fuelUp(53);
        Console.WriteLine("Vehicle has 53 KWH of fuel");
        Console.WriteLine("Vehicle can travel " + model3.distanceOnFuel() + " miles on it's current tank of gas");


        var corolla = new Corolla(CarConfig4.vin, CarConfig4.yearBuilt);
        corolla.printRegistration();
        corolla.fuelUp(13);
        Console.WriteLine("Vehicle has 13 Galleons of fuel");
        Console.WriteLine("Vehicle can travel " + corolla.distanceOnFuel() + " miles on it's current tank of gas");

    }
}
