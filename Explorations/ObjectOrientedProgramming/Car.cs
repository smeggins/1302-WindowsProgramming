using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Car
{
    private int vinNumber;
    private Dashboard dashboard;
    private Engine engine;
    private string brand;
    private string model;
    private int yearBuilt;

    public Car() { }
    public Car(int vinNumber, string brand, string model, int yearBuilt)
    {
        this.vinNumber = vinNumber;
        this.brand = brand;
        this.model = model;
        this.yearBuilt = yearBuilt;

        this.dashboard = new Dashboard();
        this.engine = new Engine();
    }

    public void speedUp(int delta)
    {
        dashboard.currSpeed += delta;
    }
    public void speedUp2(int delta) => dashboard.currSpeed += delta;
         
    public DashboardState getDashBoardState()
    {
        var oilStatus = this.engine.getOilStatus();
        return new DashboardState()
        {
            mileage = this.dashboard.mileage,
            currSpeed = this.dashboard.currSpeed,
            fuel = this.dashboard.fuel,
            checkOil = (oilStatus == Engine.oilStatus.Insufficient)
        };
    }

    public void print()
    {
        Console.WriteLine("\nthe cars info is as follows:");
        Console.WriteLine("brand: " + this.brand);
        Console.WriteLine("model: " + this.model);
        Console.WriteLine("year: " + this.yearBuilt);
    }

    public static void test()
    {
        var car1 = new Car(CarConfig.vin, CarConfig.brand, CarConfig.model, CarConfig.yearBuilt);
        car1.print();

        car1.speedUp(15);
        car1.getDashBoardState().print();

        car1.speedUp(35);
        car1.getDashBoardState().print();
    }
}

