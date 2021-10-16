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

    public string getRegistration()
    {
        var sb = new StringBuilder();
        sb.Append("brand: " + this.registration.brand + "\n");
        sb.Append("model: " + this.registration.model + "\n");
        sb.Append("year: " + this.registration.yearBuilt + "\n");
        sb.Append("vin Number: " + this.registration.vinNumber);

        return sb.ToString();
    }

    public virtual int distanceOnFuel() => -1;
    public virtual void fuelUp(int amount) { }
    public float getMilePer() => milePer;
    public Registration accessRegistration() => registration;
}



