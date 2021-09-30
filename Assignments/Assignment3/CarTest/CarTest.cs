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

        var leaf = new Leaf(CarConfig2.vin, CarConfig2.yearBuilt);
        leaf.printRegistration();

        var model3 = new Model3(CarConfig3.vin, CarConfig3.yearBuilt);
        model3.printRegistration();

        var corolla = new Corolla(CarConfig4.vin, CarConfig4.yearBuilt);
        corolla.printRegistration();
    }
}
