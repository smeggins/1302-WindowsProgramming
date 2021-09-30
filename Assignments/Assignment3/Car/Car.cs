using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class CarV2
{
    public Dashboard dashboard;
    protected Engine engine;
    protected Registration registration;
    protected float milePer;

    public CarV2() { }
    public CarV2(int vinNumber, string brand, string model, int yearBuilt, float milePer)
    {
        registration = new Registration(vinNumber, brand, model, yearBuilt);
        this.dashboard = new Dashboard();
        this.milePer = milePer;
    }

    public void speedUp(int delta)
    {
        dashboard.currSpeed = engine.speedUp(delta);
    }
    public void speedDown(int delta)
    {
        dashboard.currSpeed = engine.speedDown(delta);
    }

    public void printRegistration()
    {
        Console.WriteLine("\nthe cars info is as follows:");
        Console.WriteLine("brand: " + this.registration.brand);
        Console.WriteLine("model: " + this.registration.model);
        Console.WriteLine("year: " + this.registration.yearBuilt);
        Console.WriteLine("vin Number: " + this.registration.vinNumber);
    }

    public virtual int distanceOnFuel() => -1;

    //public static void test()
    //{
    //    var car1 = new CarV2(CarConfig1.vin, CarConfig1.brand, CarConfig1.model, CarConfig1.yearBuilt);
    //    car1.print();

    //    car1.dashboard.print();
    //    car1.speedUp(15);
    //    car1.dashboard.print();

    //    var car2 = new CarV2(CarConfig2.vin, CarConfig2.brand, CarConfig2.model, CarConfig2.yearBuilt);
    //    car2.print();

    //    car2.dashboard.print();
    //    car2.speedUp(15);
    //    car2.dashboard.print();
    //}
}



